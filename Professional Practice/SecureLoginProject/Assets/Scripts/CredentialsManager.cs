using System.Collections.Generic;
using System.Security.Cryptography; // Needed for cryptographic services including secure encoding and decoding
using System.Text;
using System.Text.RegularExpressions; // Needed for regex
using System;

/// <summary>
/// Manages user credentials, including registration, validation, and password hashing.
/// </summary>
public class CredentialsManager
{
    /// <summary>
    /// In-memory storage for user credentials, where the key is the user's email (normalized to lowercase) and the value is the hashed password.
    /// </summary>
    private Dictionary<string, string> userDatabase = new Dictionary<string, string>();

    /// <summary>
    /// Validates if the provided email has a valid format.
    /// </summary>
    /// <param name="email">The email to validate.</param>
    /// <returns>True if the email format is valid, otherwise false.</returns>
    public bool IsValidEmail(string email)
    {
        // Regular expression for validating an email address
        string emailPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
        return Regex.IsMatch(email, emailPattern);
    }

    /// <summary>
    /// Registers a new user in the database.
    /// </summary>
    /// <param name="email">The email of the user.</param>
    /// <param name="password">The password of the user.</param>
    public void RegisterUser(string email, string password)
    {
        // Validate the email format
        if (!IsValidEmail(email))
        {
            throw new ArgumentException("Invalid email format.");
        }

        // Make the email all lowercase
        string normalizedEmail = email.ToLowerInvariant();

        // Hash the password
        string hashedPassword = HashPassword(password);

        // Store the email and hashed password in the dictionary
        userDatabase[normalizedEmail] = hashedPassword;
    }

    /// <summary>
    /// Validates a user by checking if the provided email and password match any entry in the userDatabase.
    /// </summary>
    /// <param name="email">The email of the user.</param>
    /// <param name="password">The password of the user.</param>
    /// <returns>True if the user is valid, otherwise false.</returns>
    public bool ValidateUser(string email, string password)
    {
        // Normalize email to lowercase for comparison
        string normalizedEmail = email.ToLowerInvariant();

        // Check if the email exists already
        if (userDatabase.ContainsKey(normalizedEmail))
        {
            // Retrieve the stored hashed password
            string storedHashedPassword = userDatabase[normalizedEmail];

            // Hash the provided password
            string hashedPassword = HashPassword(password);

            // Compare the stored hashed password with the hashed version of the provided password
            return storedHashedPassword == hashedPassword;
        }

        // If the email isn't in the database - return false
        return false;
    }

    /// <summary>
    /// Hashes a password using the PBKDF2 algorithm with SHA-256 as the underlying hash function.
    /// </summary>
    /// <param name="password">The password to hash.</param>
    /// <returns>The hashed password as a hexadecimal string.</returns>
    private string HashPassword(string password)
    {
        // Create instance using the provided password, salt, and 10000 iterations
        using (var rfc2898 = new Rfc2898DeriveBytes(password, Encoding.UTF8.GetBytes("Randomsaltesrdiufhb4q3805tgbieuarbg"), 10000))
        {
            // Get a 20 byte hash of the password
            byte[] hash = rfc2898.GetBytes(20);

            // Convert to hexadecimal string
            StringBuilder builder = new StringBuilder();
            foreach (byte b in hash)
            {
                builder.Append(b.ToString("x2"));
            }

            // Return the hexadecimal string
            return builder.ToString();
        }
    }
}
