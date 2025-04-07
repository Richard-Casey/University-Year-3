using MongoDB.Bson; // For handlelling BSON (Binary JSON) data
using MongoDB.Driver; //  Classes fo rinteracting with MongoDB
using System.Collections;
using System.Threading.Tasks;
using UnityEngine;
using System;
using System.Security.Cryptography;
using System.Text;
using System.IO;

public class MongoDBManager : MonoBehaviour
{
    private MongoClient client;
    private IMongoDatabase database;
    private IMongoCollection<BsonDocument> collection;

    private MongoDBConfig config;

    void Start()
    {
        LoadConfiguration();
        ConnectToDatabase();
    }

    // Load MongoDB configuration from a JSON file
    private void LoadConfiguration()
    {
        // Make a path to the configuration file
        string path = Path.Combine(Application.streamingAssetsPath, "mongodb_config.json");

        // Check if it already exists
        if (File.Exists(path))
        {

            // Read the file's content and de-serialise it into a MongoDBConfig object
            string json = File.ReadAllText(path);
            config = JsonUtility.FromJson<MongoDBConfig>(json);
            
        }
        else
        {
            Debug.LogError("Configuration file not found at " + path);
        }
    }

    // Connect to MongoDB
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

            // Initialise the MongoDB Client
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

    public async Task RegisterUser(string email, string password)
    {
        // Check if the collection is initialised
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

        // Create a new document with the users email and hasked password
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

    public async Task<bool> ValidateUser(string email, string password)
    {
        // Check the collections initialised
        if (collection == null)
        {
            Debug.LogError("MongoDB collection is not initialized.");
            return false;
        }

        // Create a filter to find the user by email
        var filter = Builders<BsonDocument>.Filter.Eq("email", email.ToLowerInvariant());
        var result = await collection.Find(filter).FirstOrDefaultAsync();

        // If the user is found - compare the stored hashed pw with the provided pw
        if (result != null)
        {
            string storedHashedPassword = result["password"].AsString;
            string hashedPassword = HashPassword(password);
            return storedHashedPassword == hashedPassword;
        }

        return false;
    }

    private string HashPassword(string password)
    {
        using (var sha256 = SHA256.Create())
        {
            // Concatenate the salt with the pw
            var saltedPassword = "Randomsaltesrdiufhb4q3805tgbieuarbg" + password;  

            // Comppute the SHA256 hash of the salted pw
            byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(saltedPassword));

            // Convert the hash bytes to hexadecimal string
            StringBuilder builder = new StringBuilder();
            foreach (byte b in bytes)
            {
                builder.Append(b.ToString("x2"));
            }
            return builder.ToString();
        }
    }
}
