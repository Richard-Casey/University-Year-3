﻿using System.Collections;
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

        animator = GetComponent<Animator>();


        int randomIndex = Random.Range(0, corridorWaypoints.Length);
        transform.position = corridorWaypoints[randomIndex].position;


        currentTarget = centerWaypoint;
    }

    void Update()
    {
        if (isPaused)
        {
            animator.SetBool("IsRunning", false);
            return;
        }


        float step = speed * Time.deltaTime;
        Vector3 newPosition = Vector3.MoveTowards(transform.position, currentTarget.position, step);
        transform.position = newPosition;


        Vector3 direction = (currentTarget.position - transform.position).normalized;
        if (direction != Vector3.zero)
        {
            Quaternion lookRotation = Quaternion.LookRotation(direction, Vector3.up);
            lookRotation.x = 0;
            lookRotation.z = 0;
            transform.rotation = lookRotation;
        }


        if (Vector3.Distance(transform.position, currentTarget.position) < 0.1f)
        {
            animator.SetBool("IsRunning", false);

            if (currentTarget == centerWaypoint)
            {
                // At the center, pause for a moment
                StartCoroutine(PauseAtCenter());
            }
            else
            {
                // At The corridor
                int randomIndex;
                do
                {
                    randomIndex = Random.Range(0, corridorWaypoints.Length);
                } while (currentTarget == corridorWaypoints[randomIndex]);

                transform.position = corridorWaypoints[randomIndex].position;

                // Next target is the center
                currentTarget = centerWaypoint;
            }
        }
        else
        {
            animator.SetBool("IsRunning", true); // Play running animation
        }
    }

    IEnumerator PauseAtCenter()
    {
        isPaused = true;
        yield return new WaitForSeconds(pauseTime);
        isPaused = false;

        // Pick a random corridor 
        int randomIndex = Random.Range(0, corridorWaypoints.Length);
        currentTarget = corridorWaypoints[randomIndex];
    }
}