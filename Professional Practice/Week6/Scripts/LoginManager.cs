using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Threading.Tasks;

/// <summary>
/// Manages user login and registration processes, including interaction with MongoDB and JWT generation.
/// </summary>
public class LoginManager : MonoBehaviour
{
    /// <summary>
    /// The input field for the user's email.
    /// </summary>
    public TMP_InputField emailInputField;

    /// <summary>
    /// The input field for the user's password.
    /// </summary>
    public TMP_InputField passwordInputField;

    /// <summary>
    /// The button used to trigger the login process.
    /// </summary>
    public Button loginButton;

    /// <summary>
    /// The button used to trigger the registration process.
    /// </summary>
    public Button registerButton;

    /// <summary>
    /// The text field used to display feedback messages to the user.
    /// </summary>
    public TextMeshProUGUI feedbackText;

    private MongoDBManager mongoDBManager;
    private JwtTokenGenerator tokenGenerator;
    private CredentialsManager credentialsManager;

    /// <summary>
    /// Initializes the LoginManager by setting up dependencies and adding button listeners.
    /// </summary>
    void Start()
    {
        // Get the MongoDBManager component
        mongoDBManager = GetComponent<MongoDBManager>();

        // Instantiate the JwtTokenGenerator
        tokenGenerator = new JwtTokenGenerator();

        // Instantiate the CredentialsManager
        credentialsManager = new CredentialsManager();

        // Check if the MongoDBManager component is found
        if (mongoDBManager == null)
        {
            Debug.LogError("MongoDBManager component is not found!");
        }

        // Add listeners to buttons
        loginButton.onClick.AddListener(() => StartCoroutine(LoginUser()));
        registerButton.onClick.AddListener(() => StartCoroutine(RegisterUser()));
    }

    /// <summary>
    /// Handles the login button click event.
    /// </summary>
    public void OnLoginButtonClick()
    {
        StartCoroutine(LoginUser());
    }

    /// <summary>
    /// Registers a new user with the provided email and password.
    /// </summary>
    private IEnumerator RegisterUser()
    {
        // Check for internet connectivity
        if (!ConnectivityChecker.IsInternetAvailable())
        {
            feedbackText.text = "No internet connection.";
            yield break;
        }

        // Gets the email and password from the input fields
        string email = emailInputField.text;
        string password = passwordInputField.text;

        bool emailValid;
        try
        {
            // Validate the email format
            emailValid = credentialsManager.IsValidEmail(email);
        }
        catch (ArgumentException ex)
        {
            feedbackText.text = ex.Message;
            yield break;
        }

        if (!emailValid)
        {
            feedbackText.text = "Invalid email format.";
            yield break;
        }

        // Start the registration
        Task registerTask = mongoDBManager.RegisterUser(email, password);
        yield return new WaitUntil(() => registerTask.IsCompleted);

        // Check to see if there was an exception
        if (registerTask.Exception != null)
        {
            // If the user already exists - display this message
            if (registerTask.Exception.InnerException != null && registerTask.Exception.InnerException.Message == "User already exists.")
            {
                feedbackText.text = "User already exists. Please use a different email.";
            }
            else
            {
                feedbackText.text = "Registration Failed: " + registerTask.Exception;
            }
        }
        else
        {
            // Confirmed new user - complete registration
            feedbackText.text = "User registered successfully!";
        }
    }

    /// <summary>
    /// Logs in a user with the provided email and password.
    /// </summary>
    private IEnumerator LoginUser()
    {
        // Check for internet connectivity
        if (!ConnectivityChecker.IsInternetAvailable())
        {
            feedbackText.text = "No internet connection.";
            yield break;
        }

        // Grabs the email and password from the input fields
        string email = emailInputField.text;
        string password = passwordInputField.text;

        // Starts validating
        Task<bool> loginTask = mongoDBManager.ValidateUser(email, password);
        yield return new WaitUntil(() => loginTask.IsCompleted);

        // Checks to see if it was successful
        if (loginTask.Result)
        {
            feedbackText.text = "Login successful!";

            // Generate a JWT Token for the user
            string token = tokenGenerator.GenerateJwtToken(email);
            Debug.Log("JWT Token: " + token);
        }
        else
        {
            feedbackText.text = "Invalid email or password.";
        }
    }
}
