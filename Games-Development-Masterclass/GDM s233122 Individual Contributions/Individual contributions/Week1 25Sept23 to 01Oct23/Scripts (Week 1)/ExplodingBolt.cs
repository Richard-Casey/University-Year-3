using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Abilities/ExplodingBolt")]
public class ExplodingBolt : Ability
{
    public float explosionRadius;

    public ExplodingBolt()
    {
        abilityName = "Exploding Bolt";
        cooldown = 10.0f;
        duration = 2.0f;
        explosionRadius = 5.0f;
    }

    public override void Activate(GameObject user)
    {
        // Logic for Exploding Bolt ability in here
        Debug.Log("Shooting Exploding Bolt");
    }
}
