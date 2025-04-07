using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : Interactable
{
    private void Start()
    {
        OnInteraction.AddListener(HandlePickup);
    }

    public void Update()
    {

    }

    private void OnDestroy()
    {
        OnInteraction.RemoveListener(HandlePickup);
    }

    private void HandlePickup(GameObject player)
    {
        GameManager.Instance.AddCurrency(17);
        GameManager.Instance.UpdateCurrencyUI();
        Destroy(gameObject);
    }

}