using System.Collections.Generic;
using UnityEngine;

public enum AbilityType
{
    Melee,
    Block,
    FireWeapon,
    Dash,
    ThrowProjectile,
    Push
}

// This script needs to be attached to each playable character in the game
// The 'abilities' dictionary will be populated automatically when the game starts through the Start() method.
public class AbilityManager : MonoBehaviour
{
    public static AbilityManager Instance;

    public Dictionary<AbilityType, Abilities.Ability> abilities;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }


    private void Start()
    {
        // Initialise abilities
        abilities = new Dictionary<AbilityType, Abilities.Ability>();
        foreach (AbilityType type in System.Enum.GetValues(typeof(AbilityType)))
        {
            Abilities.Ability ability =
                System.Activator.CreateInstance(System.Type.GetType("Abilities+" + type.ToString())) as
                    Abilities.Ability;
            if (ability != null)
            {
                abilities.Add(type, ability);
            }
            else
            {
                Debug.LogWarning("Could not create ability for type: " + type.ToString());
            }
        }
    }


    public void ActivateAbility(AbilityType type, GameObject user)
    {
        if (abilities.TryGetValue(type, out Abilities.Ability ability))
            ability.Activate(user);
    }
}
}