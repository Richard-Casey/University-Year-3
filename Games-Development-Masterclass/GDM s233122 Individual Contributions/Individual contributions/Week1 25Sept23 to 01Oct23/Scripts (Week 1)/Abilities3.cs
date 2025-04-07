using UnityEngine;
using static Abilities;

// Animations for abailities currently commented out until model in place - triggers current output into console

public class Abilities : MonoBehaviour
{
    public abstract class Ability
    {
        public string abilityName;
        public float cooldown;
        public float duration;

        public abstract void Activate(GameObject user);
    }

    public class Melee : Ability
    {
        public float damage;

        public Melee()
        {
            abilityName = "Melee Attack";
            cooldown = 0.1f;
            duration = 0.2f;
            damage = 4.0f;
        }

        public override void Activate(GameObject user)
            //{
            //    animator.SetTrigger(StrongMeleeAttackAnimation);
            //}
            Debug.Log("Performing Melee Attack");
        }
}

public class Block : Ability
{
    public Block()
    {
        abilityName = "Block";
        cooldown = 4.5f;
        duration = 4.0f;
    }

    //{
    //    animator.SetTrigger(BlockAnimation);
    //}
    Debug.Log("Performing Block");
        }
    }

    public class Dash : Ability
{

    public Dash()
    {
        abilityName = "Dash";
        cooldown = 4.0f;
        duration = 1.5f;
        dashDistance = 3.0f;
    }
}
    }


    public class FireWeapon : Ability
{

    public FireWeapon()
    {
        abilityName = "Fire Weapon";
        cooldown = 0.5f;
        duration = 0.15f;
    }

    public override void Activate(GameObject user)
            //{
            //    animator.SetTrigger(DrawArrowAnimation);
            //}
            Debug.Log("Firing Weapon");
        }
    }

    public class ThrowProjectile : Ability
{
    public float projectileRadius;

    public ThrowProjectile()
    {
        abilityName = "Throw Projectile";
        cooldown = 0.8f;
        duration = 1.0f;
        projectileRadius = 3.5f;
    }

    public override void Activate(GameObject user)
            //{
            //    animator.SetTrigger(TeleportAnimation);
            //}
            Debug.Log("Throwing Projectile");
        }
    }

    public class Push : Ability
{
    public Push()
    {
        abilityName = "Push";
        cooldown = 2.5f;
        duration = 2.0f;
    }

    public override void Activate(GameObject user)
            //{
            //    animator.SetTrigger(ShieldAnimation);
            //}
            Debug.Log("Performing Push");
        }
    }
    
}