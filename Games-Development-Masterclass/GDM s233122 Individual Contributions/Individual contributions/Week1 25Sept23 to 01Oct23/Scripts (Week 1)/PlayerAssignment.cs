using System.Collections;
using TMPro;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAssignment : MonoBehaviour
{
    public enum PlayerClass
    {
        Melee,
        Range,
        AOE
    }

    public enum PlayerRole
    {
        Rescuer,
        Terroriser,
        Hacker
    }

    public PlayerClass playerClass;
    public PlayerRole playerRole;

    public TextMeshProUGUI classText;
    public TextMeshProUGUI roleText;

    // These list keep track of the roles and classes that have already been assigned to avoid duplicates
    private static List<PlayerClass> assignedClasses = new List<PlayerClass>();
    private static List<PlayerRole> assignedRoles = new List<PlayerRole>();

    void Start()
    {
        AssignRandomClassAndRole();
    }

    void AssignRandomClassAndRole()
    {
        //Assign a random class that hasnt been assigned yet
        List<PlayerClass> availibleClasses = new List<PlayerClass>((PlayerClass[])System.Enum.GetValues(typeof(PlayerClass)));
        availibleClasses.RemoveAll(item => assignedClasses.Contains(item));
        playerClass = availibleClasses[Random.Range(0, availibleClasses.Count)];
        assignedClasses.Add(playerClass);


        // Assign a random role
        List<PlayerRole> availibleRoles = new List<PlayerRole>((PlayerRole[])System.Enum.GetValues(typeof(PlayerRole)));
        availibleRoles.RemoveAll(item => assignedRoles.Contains(item));
        playerRole = availibleRoles[Random.Range(0, availibleRoles.Count)];
        assignedRoles.Add(playerRole);

        classText.text = "Class: " + playerClass.ToString();
        roleText.text = "Role: " + playerRole.ToString();
    }
}