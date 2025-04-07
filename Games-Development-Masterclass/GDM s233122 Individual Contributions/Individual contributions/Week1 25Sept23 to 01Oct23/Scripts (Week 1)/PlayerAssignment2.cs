using TMPro;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerAssignment : MonoBehaviour
{
    public TextMeshProUGUI classText;
    public TextMeshProUGUI roleText;


    void Start()
    {
        if (GameManager.Instance == null)
        {
            Debug.Log("GameManager is not initialised. Creating one now.");
            GameObject GameManager = new GameObject("GameManager");
            GameManager.AddComponent<GameManager>();
        }

        if (!GameManager.Instance.isClassAndRoleAssigned)
        {

            GameManager.Instance.AssignClassAndRole();
        }

        playerClass = GameManager.Instance.playerClass;
        playerRole = GameManager.Instance.playerRole;

        classText.text = "Class: " + playerClass.ToString();
        roleText.text = "Role: " + playerRole.ToString();

    }


    //void AssignRandomClassAndRole()
    //{
    //    Debug.Log("AssignRandomClassAndRole called in PlayerAssignment");

    //    //Assign a random class that hasnt been assigned yet
    //    List<PlayerClass> availibleClasses = new List<PlayerClass>((PlayerClass[])System.Enum.GetValues(typeof(PlayerClass)));
    //    availibleClasses.RemoveAll(item => assignedClasses.Contains(item));
    //    playerClass = availibleClasses[Random.Range(0, availibleClasses.Count)];
    //    assignedClasses.Add(playerClass);


    //    // Assign a random role
    //    List<PlayerRole> availibleRoles = new List<PlayerRole>((PlayerRole[])System.Enum.GetValues(typeof(PlayerRole)));
    //    availibleRoles.RemoveAll(item => assignedRoles.Contains(item));
    //    playerRole = availibleRoles[Random.Range(0, availibleRoles.Count)];
    //    assignedRoles.Add(playerRole);

    //    GameManager.Instance.AssignClassAndRole(playerClass, playerRole);

    //    classText.text = "Class: " + playerClass.ToString();
    //    roleText.text = "Role: " + playerRole.ToString();
    //}
}