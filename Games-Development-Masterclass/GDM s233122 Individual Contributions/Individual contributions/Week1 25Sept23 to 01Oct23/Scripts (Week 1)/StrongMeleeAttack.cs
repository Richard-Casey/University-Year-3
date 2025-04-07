using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Abilities/StrongMeleeAttack")]
public class StrongMeleeAttack : Ability
{
    public float damage;

    public StrongMeleeAttack()
    {
        abilityName = "Strong Melee Attack";
        cooldown = 5.0f;
        duration = 1.0f;
        damage = 20.0f;
    }

    public override void Activate(GameObject user)
    {
        // Logic for performing a strong melee here
        Debug.Log("Performing Strong Melee Attack");
    }

}
