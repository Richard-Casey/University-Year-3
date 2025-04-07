using System;
using System.Security.Cryptography;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class LoginManager : MonoBehaviour
{
    public InputField emailInputField;
    public InputField passwordInputField;
    public Button loginButton;

    void Start()
    {
        loginButton.onClick.AddListener(OnLoginButtonClick);
    }

    void OnLoginButtonClick()
    {
        string email = emailInputField.text;
        string password = passwordInputField.text;
        string hashedPassword = HashPassword(password);

        Debug.Log("Email: " + email + ", Hashed Password: " + hashedPassword);
    }

    string HashPassword(string password)
    {
        using (var sha256 = SHA256.Create())
        {
            var saltedPassword = "Random_Salt_TBC_When_I_Remember" + password;
            byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(saltedPassword));
            StringBuilder builder = new StringBuilder();
            foreach (byte b in bytes)
            {
                builder.Append(b.ToString("x2"));
            }
            return builder.ToString();
        }
    }
}
