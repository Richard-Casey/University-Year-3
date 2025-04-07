using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtons : MonoBehaviour
{

    public GameObject optionsMenu;
    public GameObject mainMenu;
    public GameObject customisationMenu;


    public void StartButton()
        mainMenu.SetActive(true);
        optionsMenu.SetActive(false);
    }

public void OpenCustomisationMenu()
{
    mainMenu.SetActive(false);
    customisationMenu.SetActive(true);
}

public void CloseCustomisationMenu()
{
    mainMenu.SetActive(true);
    customisationMenu.SetActive(false);
}
}