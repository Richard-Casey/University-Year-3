using MongoDB.Bson; // For handling BSON (Binary JSON) data
using MongoDB.Driver; // Classes for interacting with MongoDB
using System.Collections;
using System.Threading.Tasks;
using UnityEngine;
using System;
using System.Security.Cryptography;
using System.Text;
using System.IO;

/// <summary>
/// Manages MongoDB interactions for user registration and validation.
/// </summary>
public class MongoDBManager : MonoBehaviour
{
    /// <summary>
    /// The MongoDB client.
    /// </summary>
    private MongoClient client;

    /// <summary>
    /// The MongoDB database.
    /// </summary>
    private IMongoDatabase database;

    /// <summary>
    /// The MongoDB collection.
    /// </summary>
    private IMongoCollection<BsonDocument> collection;

    /// <summary>
    /// The configuration loaded from a JSON file.
    /// </summary>
    private MongoDBConfig config;

    /// <summary>
    /// Initializes the MongoDBManager by loading configuration and connecting to the database.
    /// </summary>
    void Start()
    {
        LoadConfiguration();
        ConnectToDatabase();
    }

    /// <summary>
    /// Loads MongoDB configuration from a JSON file.
    /// </summary>
    private void LoadConfiguration()
    {
        // Make a path to the configuration file
        string path = Path.Combine(Application.streamingAssetsPath, "mongodb_config.json");

        // Check if it already exists
        if (File.Exists(path))
        {
            // Read the file's content and deserialize it into a MongoDBConfig object
            string json = File.ReadAllText(path);
            config = JsonUtility.FromJson<MongoDBConfig>(json);
        }
        else
        {
            Debug.LogError("Configuration file not found at " + path);
        }
    }

    /// <summary>
    /// Connects to MongoDB using the loaded configuration.
    /// </summary>
    private void ConnectToDatabase()
    {
        // Make sure that the configuration has loaded
        if (config == null)
        {
            Debug.LogError("MongoDB configuration is not loaded.");
            return;
        }

        try
        {
            Debug.Log("Attempting to connect to MongoDB...");

            // Create the connection string using the configuration
            string connectionString = $"mongodb+srv://{config.username}:{Uri.EscapeDataString(config.password)}@cluster0.racmltl.mongodb.net/{config.databaseName}?retryWrites=true&w=majority";

            // Initialize the MongoDB Client
            client = new MongoClient(connectionString);
            database = client.GetDatabase(config.databaseName);
            collection = database.GetCollection<BsonDocument>(config.collectionName);
            Debug.Log("Connected to MongoDB Atlas!");
        }
        catch (Exception e)
        {
            Debug.LogError("Exception: " + e.Message);
        }
    }

    /// <summary>
    /// Registers a new user with the provided email and password.
    /// </summary>
    /// <param name="email">The email of the user.</param>
    /// <param name="password">The password of the user.</param>
    public async Task RegisterUser(string email, string password)
    {
        // Check for internet connectivity
        if (!ConnectivityChecker.IsInternetAvailable())
        {
            Debug.LogError("No internet connection available.");
            return;
        }

        // Check if the collection is initialized
        if (collection == null)
        {
            Debug.LogError("MongoDB collection is not initialized.");
            return;
        }

        // Check if the user already exists
        var filter = Builders<BsonDocument>.Filter.Eq("email", email.ToLowerInvariant());
        var existingUser = await collection.Find(filter).FirstOrDefaultAsync();

        // If the user already exists - throw an exception
        if (existingUser != null)
        {
            Debug.Log("User already exists.");
            throw new Exception("User already exists.");
        }

        // Create a new document with the user's email and hashed password
        var document = new BsonDocument
        {
            { "email", email.ToLowerInvariant() },
            { "password", HashPassword(password) }
        };

        try
        {
            // Insert the document into the collection on MongoDB
            await collection.InsertOneAsync(document);
            Debug.Log("User registered successfully!");
        }
        catch (Exception e)
        {
            Debug.LogError("Error registering user: " + e.Message);
        }
    }

    /// <summary>
    /// Validates a user with the provided email and password.
    /// </summary>
    /// <param name="email">The email of the user.</param>
    /// <param name="password">The password of the user.</param>
    /// <returns>True if the user is valid, otherwise false.</returns>
    public async Task<bool> ValidateUser(string email, string password)
    {
        // Check for internet connectivity
        if (!ConnectivityChecker.IsInternetAvailable())
        {
            Debug.LogError("No internet connection available.");
            return false;
        }

        // Check if the collection is initialized
        if (collection == null)
        {
            Debug.LogError("MongoDB collection is not initialized.");
            return false;
        }

        // Create a filter to find the user by email
        var filter = Builders<BsonDocument>.Filter.Eq("email", email.ToLowerInvariant());
        var result = await collection.Find(filter).FirstOrDefaultAsync();

        // If the user is found - compare the stored hashed password with the provided password
        if (result != null)
        {
            string storedHashedPassword = result["password"].AsString;
            string hashedPassword = HashPassword(password);
            return storedHashedPassword == hashedPassword;
        }

        return false;
    }

    /// <summary>
    /// Hashes a password using the SHA-256 algorithm with a salt.
    /// </summary>
    /// <param name="password">The password to hash.</param>
    /// <returns>The hashed password as a hexadecimal string.</returns>
    private string HashPassword(string password)
    {
        using (var sha256 = SHA256.Create())
        {
            // Concatenate the salt with the password
            var saltedPassword = "Randomsaltesrdiufhb4q3805tgbieuarbg" + password;

            // Compute the SHA-256 hash of the salted password
            byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(saltedPassword));

            // Convert the hash bytes to a hexadecimal string
            StringBuilder builder = new StringBuilder();
            foreach (byte b in bytes)
            {
                builder.Append(b.ToString("x2"));
            }
            return builder.ToString();
        }
    }
}
