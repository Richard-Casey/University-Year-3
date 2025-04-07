using UnityEngine;
using TMPro;

public class TabNavigation : MonoBehaviour
{
    public TMP_InputField emailInputField;
    public TMP_InputField passwordInputField;
    public LoginManager loginManager;

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
