using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Threading.Tasks;

public class LoginManager : MonoBehaviour
{
    public TMP_InputField emailInputField;
    public TMP_InputField passwordInputField;
    public Button loginButton;
    public Button registerButton;
    public TextMeshProUGUI feedbackText;

    private MongoDBManager mongoDBManager;
    private JwtTokenGenerator tokenGenerator;

    void Start()
    {
        // Get the MongoDBManager component
        mongoDBManager = GetComponent<MongoDBManager>();

        // Instantiate the JwtTokenGenerator
        tokenGenerator = new JwtTokenGenerator();


    // Check if the MongoDBManager component is found
        if (mongoDBManager == null)
        {
            Debug.LogError("MongoDBManager component is not found!");
        }

        // Add listeners to buttons
        loginButton.onClick.AddListener(() => StartCoroutine(LoginUser()));
        registerButton.onClick.AddListener(() => StartCoroutine(RegisterUser()));
    }

    public void OnLoginButtonClick() // Make this method public
    {
        StartCoroutine(LoginUser());
    }

    private IEnumerator RegisterUser()
    {
        // Gets the email and password from the input fields
        string email = emailInputField.text;
        string password = passwordInputField.text;

        // Starts the registration
        Task registerTask = mongoDBManager.RegisterUser(email, password);
        yield return new WaitUntil(() => registerTask.IsCompleted);

        // Checkm to see if there was an exception
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


    private IEnumerator LoginUser()
    {
        // Grabs the email and password from the input fields
        string email = emailInputField.text;
        string password = passwordInputField.text;

        // Starts validating
        Task<bool> loginTask = mongoDBManager.ValidateUser(email, password);
        yield return new WaitUntil(() => loginTask.IsCompleted);

        // Checks to see if it was sucessful
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
