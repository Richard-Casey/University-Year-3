using System.Collections;
using TMPro;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public PlayerAssignment.PlayerClass playerClass;
    public PlayerAssignment.PlayerRole playerRole;

    public bool isClassAndRoleAssigned = false;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        if (SceneManager.GetActiveScene().name == "Character Assignment" && !isClassAndRoleAssigned)
        {
            AssignClassAndRole();
        }
    }


    public void AssignClassAndRole()
    {
        Debug.Log("AssignClassAndRole called in GameManager");

        // Assign a random class that hasn't been assigned yet
        List<PlayerAssignment.PlayerClass> availableClasses = new List<PlayerAssignment.PlayerClass>((PlayerAssignment.PlayerClass[])System.Enum.GetValues(typeof(PlayerAssignment.PlayerClass)));
        playerClass = availableClasses[Random.Range(0, availableClasses.Count)];

        // Assign a random role
        List<PlayerAssignment.PlayerRole> availableRoles = new List<PlayerAssignment.PlayerRole>((PlayerAssignment.PlayerRole[])System.Enum.GetValues(typeof(PlayerAssignment.PlayerRole)));
        playerRole = availableRoles[Random.Range(0, availableRoles.Count)];

        isClassAndRoleAssigned = true;
    }


    public void LoadMainScene()
    {
        SceneManager.LoadScene("Main Scene");
    }
}