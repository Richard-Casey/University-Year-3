﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Customisation : MonoBehaviour
{
    public Transform playerParent; // The parent GameObject where the player should be instantiated
    private GameObject[] playerPrefabs;
    private GameObject currentPlayer;
    private int currentPlayerIndex = 0;

    public event Action<int> OnPrefabSelected;

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
        {
            Debug.Log("O key pressed. Trying to switch to next player.");
            NextPlayer();
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            Debug.Log("P key pressed. Trying to switch to previous player.");
            PreviousPlayer();
        }
    }


    public void NextPlayer()
    {
        Vector3 currentPosition = currentPlayer.transform.position;
        Transform currentTarget = currentPlayer.GetComponent<WaypointRunner>().GetCurrentTarget();
        bool isPaused = currentPlayer.GetComponent<WaypointRunner>().IsPaused();

        Destroy(currentPlayer);

        currentPlayerIndex = (currentPlayerIndex + 1) % playerPrefabs.Length;
        currentPlayer = Instantiate(playerPrefabs[currentPlayerIndex], playerParent.position, Quaternion.identity, playerParent);

        SetInitialState(currentPosition, currentTarget, isPaused);
    }

    public void PreviousPlayer()
    {
        Vector3 currentPosition = currentPlayer.transform.position;
        Transform currentTarget = currentPlayer.GetComponent<WaypointRunner>().GetCurrentTarget();
        bool isPaused = currentPlayer.GetComponent<WaypointRunner>().IsPaused();

        Destroy(currentPlayer);

        currentPlayerIndex--;
        if (currentPlayerIndex < 0)
        {
            currentPlayerIndex = playerPrefabs.Length - 1;
        }
        currentPlayer = Instantiate(playerPrefabs[currentPlayerIndex], playerParent.position, Quaternion.identity, playerParent);

        SetInitialState(currentPosition, currentTarget, isPaused);
    }


    public void SetInitialState(Vector3 position, Transform target, bool isPaused)
    {
        currentPlayer.transform.position = position;  // This line should set the new prefab's position
        WaypointRunner waypointRunner = currentPlayer.GetComponent<WaypointRunner>();
        waypointRunner.SetInitialState(target, isPaused);
    }

    public void SelectPrefab(int index)
    {
        Debug.Log("SelectPrefab called with index: " + index);
        // Store the selected prefab index for later use
        currentPlayerIndex = index;
        OnPrefabSelected?.Invoke(index);
    }


    public void ConfirmSelection()
    {
        Debug.Log("ConfirmSelection called. Current index: " + currentPlayerIndex);
        // Instantiate the selected prefab
        Destroy(currentPlayer);
        currentPlayer = Instantiate(playerPrefabs[currentPlayerIndex], playerParent.position, Quaternion.identity, playerParent);
    }

    public int GetCurrentPlayerIndex()
    {
        return currentPlayerIndex;
    }

}