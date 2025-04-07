// SCRIPT BY ADAM BAKER - CHANGES MADE BY RCASEY COMMENTED
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(SphereCollider))]
public class Interactable : MonoBehaviour
{

    [SerializeField] float InteractionDistance = 1f;
    [SerializeField] UnityEvent<GameObject> OnEnterInteractionArea;
    [SerializeField] protected UnityEvent<GameObject> OnInteraction; // ALTERED BY RCASEY
    [SerializeField] UnityEvent<GameObject> OnStay;
    [SerializeField] UnityEvent<GameObject> OnLeaveInteractionArea;

    [ExecuteInEditMode]
    void Awake()
    {
        SphereCollider collider;
        if (!gameObject.TryGetComponent<SphereCollider>(out collider))
        {
            SphereCollider thisCollider = gameObject.AddComponent<SphereCollider>();
            thisCollider.isTrigger = true;
        }

        collider.isTrigger = true;
        collider.radius = InteractionDistance;
    }


    void OnTriggerEnter(Collider collider)
    {
        OnEnterInteractionArea.Invoke(collider.gameObject);
        InputManager.Interaction.AddListener(OnInteraction.Invoke);
    }