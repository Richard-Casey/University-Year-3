using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Customisation : MonoBehaviour
{
    public Transform playerParent; // The parent GameObject where the player should be instantiated
    private GameObject[] playerPrefabs;
    private GameObject currentPlayer;
    private int currentPlayerIndex = 0;

    void Start()
    {
        // Load all the player prefabs from the Resources/PlayerPrefabs folder into the array
        playerPrefabs = Resources.LoadAll<GameObject>("PlayerPrefabs");
        Debug.Log("Loaded prefabs: " + string.Join(", ", System.Array.ConvertAll(playerPrefabs, prefab => prefab.name)));
        // Instantiate the initial player prefab
        currentPlayer = Instantiate(playerPrefabs[currentPlayerIndex], playerParent.position, Quaternion.identity, playerParent);
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.O))
            waypointRunner.SetInitialState(target, isPaused);
    }

    public void SelectPrefab(int index)
    {
        Debug.Log("SelectPrefab called with index: " + index);
        // Store the selected prefab index for later use
        currentPlayerIndex = index;
    }


    public void ConfirmSelection()
    {
        Debug.Log("ConfirmSelection called. Current index: " + currentPlayerIndex);
        // Instantiate the selected prefab
        Destroy(currentPlayer);
        currentPlayer = Instantiate(playerPrefabs[currentPlayerIndex], playerParent.position, Quaternion.identity, playerParent);
    }





}