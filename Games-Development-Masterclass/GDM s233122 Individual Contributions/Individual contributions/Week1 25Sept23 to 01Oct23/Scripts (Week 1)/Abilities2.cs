using UnityEngine;

// Animations for abailities currently commented out until model in place - triggers current output into console

public class Abilities : MonoBehaviour
{
    public abstract class Ability

        public override void Activate(GameObject user)
    {
        //Animator animator = user.GetComponent<Animator>();
        //if (animator != null)
        //{
        //    animator.SetTrigger(StrongMeleeAttackAnimation);
        //}
        Debug.Log("Performing Strong Melee Attack");
    }
}

public override void Activate(GameObject user)
{
    //Animator animator = user.GetComponent<Animator>();
    //if (animator != null)
    //{
    //    animator.SetTrigger(BlockAnimation);
    //}
    Debug.Log("Blocking");
}
    }

        public override void Activate(GameObject user)
{
    //Animator animator = user.GetComponent<Animator>();
    //if (animator != null)
    //{
    //    animator.SetTrigger(DashAnimation);
    //}
    Debug.Log("Performing Dash");
}
    }

        public override void Activate(GameObject user)
{
    //Animator animator = user.GetComponent<Animator>();
    //if (animator != null)
    //{
    //    animator.SetTrigger(PunchAnimation);
    //}
    Debug.Log("Default Attack (Melee)");
}
    }

        public override void Activate(GameObject user)
{
    //Animator animator = user.GetComponent<Animator>();
    //if (animator != null)
    //{
    //    animator.SetTrigger(DrawArrowAnimation);
    //}
    Debug.Log("Shooting Exploding Bolt");
}
    }

        public override void Activate(GameObject user)
{
    //Animator animator = user.GetComponent<Animator>();
    //if (animator != null)
    //{
    //    animator.SetTrigger(TeleportAnimation);
    //}
    Debug.Log("Teleporting");
}
    }

        public override void Activate(GameObject user)
{
    //Animator animator = user.GetComponent<Animator>();
    //if (animator != null)
    //{
    //    animator.SetTrigger(ShieldAnimation);
    //}
    Debug.Log("Deploying Shield");
}
    }

        public override void Activate(GameObject user)
{
    //Animator animator = user.GetComponent<Animator>();
    //if (animator != null)
    //{
    //    animator.SetTrigger(DrawArrowAnimation);
    //}
    Debug.Log("Default Attack (Three Arrows)");
}
    }
