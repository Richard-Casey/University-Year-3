using UnityEngine;
using TMPro;

/// <summary>
/// Manages tab navigation between email and password input fields, and handles login on Enter key press.
/// </summary>
public class TabNavigation : MonoBehaviour
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
    /// The login manager responsible for handling login operations.
    /// </summary>
    public LoginManager loginManager;

    /// <summary>
    /// Updates the tab navigation and login handling on key press events.
    /// </summary>
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (emailInputField.isFocused)
            {
                passwordInputField.Select();
            }
            else if (passwordInputField.isFocused)
            {
                emailInputField.Select();
            }
        }

        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            if (emailInputField.isFocused || passwordInputField.isFocused)
            {
                Debug.Log("Enter key pressed.");
                loginManager.OnLoginButtonClick();
            }
        }
    }
}
