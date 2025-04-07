using System.Collections;
using UnityEngine;

public class WaypointRunner : MonoBehaviour
{
    public Transform[] corridorWaypoints;
    public Transform centerWaypoint;
    public float speed = 5.0f;
    public float pauseTime = 1.0f;
    private Transform currentTarget;
    private bool isPaused = false;
    private Animator animator;

    void Start()
    {
        // Dynamically find and assign the waypoints
        Transform roomTransform = GameObject.Find("MainMenuFountain").transform;
        Transform triggerPointsTransform = roomTransform.Find("TriggerPoints");

        corridorWaypoints = new Transform[4];
        corridorWaypoints[0] = triggerPointsTransform.Find("North");
        corridorWaypoints[1] = triggerPointsTransform.Find("South");
        corridorWaypoints[2] = triggerPointsTransform.Find("West");
        corridorWaypoints[3] = triggerPointsTransform.Find("East");

        // Assign centerWaypoint
        centerWaypoint = triggerPointsTransform.Find("Center");

        animator = GetComponent<Animator>();

        int randomIndex = Random.Range(0, corridorWaypoints.Length);
        transform.position = corridorWaypoints[randomIndex].position;

        currentTarget = centerWaypoint;
    }

    void Update()
    {
        if (isPaused)
        {