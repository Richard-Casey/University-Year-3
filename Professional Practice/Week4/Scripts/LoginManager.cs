using System;
using System.Security.Cryptography; // Needed for cryptographic operations
using System.Text;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class LoginManager : MonoBehaviour
{
    // References to UI
    public TMP_InputField emailInputField;
    public TMP_InputField passwordInputField;
    public Button loginButton;

    private JwtTokenGenerator tokenGenerator;

    void Start()
    {
        tokenGenerator = new JwtTokenGenerator();
        loginButton.onClick.AddListener(OnLoginButtonClick);
    }

    // This is called when login button is clicked
    void OnLoginButtonClick()
    {
        // Get the text entered in the email and password input fields
        string email = emailInputField.text;
        string password = passwordInputField.text;

        // Hash the password using the HashPassword method
        string hashedPassword = HashPassword(password);

        // Log the email and hashed password for debugging purposes
        Debug.Log("Email: " + email + ", Hashed Password: " + hashedPassword);

        // Generate JWT token
        string token = tokenGenerator.GenerateJwtToken(email);
        Debug.Log("JWT Token: " + token);
    }

    // Method to hash the password
    string HashPassword(string password)
    {
        // Create a new instance of SHA256
        using (var sha256 = SHA256.Create())
        {
            // Add a salt to the password (a string that will be added to the password before hashing)
            var saltedPassword = "Random_Salt_TBC_When_I_Remember" + password;

            // Compute the hash of the salted password
            byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(saltedPassword));

            // Convert the hash bytes to a hexadecimal string
            StringBuilder builder = new StringBuilder();
            foreach (byte b in bytes)
            {
                builder.Append(b.ToString("x2"));
            }

            // Return the hexadecimal string representation of the hash
            return builder.ToString();
        }
    }
}
