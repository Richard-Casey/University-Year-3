using UnityEngine;

public class Abilities : MonoBehaviour
{
    public abstract class Ability
    {
        public string abilityName;
        public float cooldown;
        public float duration;

        public abstract void Activate(GameObject user);
    }

    // Intended for female character
    public class StrongMeleeAttack : Ability
    {
        public float damage;

        public StrongMeleeAttack()
        {
            abilityName = "Strong Melee Attack";
            cooldown = 5.0f;
            duration = 1.0f;
            damage = 12.0f;
        }

        public override void Activate(GameObject user)
        {
            Debug.Log("Performing Strong Melee Attack");
        }
    }

    // Intended for female character
    public class Block : Ability
    {
        public Block()
        {
            abilityName = "Block";
            cooldown = 7.5f;
            duration = 4.0f;
        }

        public override void Activate(GameObject user)
        {
            Debug.Log("Blocking");
        }
    }

    //Intended for female Character
    public class Dash : Ability
    {

        public float dashDistance;

        public Dash()
        {
            abilityName = "Dash";
            cooldown = 5.0f;
            duration = 1.5f;
            dashDistance = 3.0f;
        }

        public override void Activate(GameObject user)
        {
            Debug.Log("Performing Dash");
        }
    }

    // Intended for female character
    public class Melee : Ability
    {
        public float damage;

        public Melee()
        {
            abilityName = "Melee Attack";
            cooldown = 0.01f;
            duration = 0.2f;
            damage = 3.0f;
        }

        public override void Activate(GameObject user)
        {
            Debug.Log("Default Attack (Melee)");
        }
    }



    // Intended for male character
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
            Debug.Log("Shooting Exploding Bolt");
        }
    }

    // Intended for male character
    public class Teleport : Ability
    {
        public float teleportDistance;

        public Teleport()
        {
            abilityName = "Teleport";
            cooldown = 8.0f;
            duration = 1.0f;
            teleportDistance = 5.0f;
        }

        public override void Activate(GameObject user)
        {
            Debug.Log("Teleporting");
        }
    }

    //Intended for male character
    public class Shield : Ability
    {
        public Shield()
        {
            abilityName = "Shield";
            cooldown = 10.0f;
            duration = 3.5f;
        }

        public override void Activate(GameObject user)
        {
            Debug.Log("Deploying Shield");
        }
    }

    //Intended for male character
    public class ThreeArrowAttack : Ability
    {
        public float damage;

        public ThreeArrowAttack()
        {
            abilityName = "Three Arrow Attack";
            cooldown = 0.01f;
            duration = 0.2f;
            damage = 3.0f;
        }

        public override void Activate(GameObject user)
        {
            Debug.Log("Default Attack (Three Arrows");
        }
    }

}