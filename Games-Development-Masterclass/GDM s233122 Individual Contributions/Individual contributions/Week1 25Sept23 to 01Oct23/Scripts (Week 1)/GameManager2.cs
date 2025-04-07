using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;  

public class GameManager : MonoBehaviour
{

    public bool isClassAndRoleAssigned = false;

    // Add this Dictionary to map PlayerClass to a pair of AbilityType
    public Dictionary<PlayerAssignment.PlayerClass, (AbilityType, AbilityType)> classAbilities = new Dictionary<PlayerAssignment.PlayerClass, (AbilityType, AbilityType)>
    {
        { PlayerAssignment.PlayerClass.Melee, (AbilityType.Melee, AbilityType.Block) },
        { PlayerAssignment.PlayerClass.Range, (AbilityType.FireWeapon, AbilityType.Dash) },
        { PlayerAssignment.PlayerClass.AOE, (AbilityType.ThrowProjectile, AbilityType.Push) }
    };

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);

            if (!isClassAndRoleAssigned)
            {
                playerClass = (PlayerAssignment.PlayerClass)Random.Range(0, System.Enum.GetValues(typeof(PlayerAssignment.PlayerClass)).Length);
                playerRole = (PlayerAssignment.PlayerRole)Random.Range(0, System.Enum.GetValues(typeof(PlayerAssignment.PlayerRole)).Length);
                isClassAndRoleAssigned = true;
            }
        }
        else
        {
        }
    }


    public void AssignClassAndRole(PlayerAssignment.PlayerClass pClass, PlayerAssignment.PlayerRole pRole)
    {
        playerClass = pClass;
        playerRole = pRole;
        isClassAndRoleAssigned = true;
    }

    // Add this method to get the abilities for a given class
    public (AbilityType, AbilityType) GetAbilitiesForClass(PlayerAssignment.PlayerClass pClass)
    {
        return classAbilities[pClass];
    }

    public void LoadMainScene()
    {