using System.Collections.Generic;
using UnityEngine;

public enum AbilityType
{
    Melee,
    Block,
    Dash,
    StrongMeleeAttack,
    ThreeArrowAttack,
    Shield,
    Teleport,
    ExplodingBolt
}

// This script needs to be attached to each playable character in the game
// The 'abilities' array will be populated automatically when the game starts through the Start() method.
public class AbilityManager : MonoBehaviour
{
    public Dictionary<AbilityType, Abilities.Ability> abilities;
    public Dictionary<KeyCode, AbilityType> keyBindings;

    private void Start()
    {
        // Initialise abilities
        abilities = new Dictionary<AbilityType, Abilities.Ability>();
        foreach (AbilityType type in System.Enum.GetValues(typeof(AbilityType)))
        {
            Abilities.Ability ability =
                System.Activator.CreateInstance(System.Type.GetType("Abilities+" + type.ToString())) as
                    Abilities.Ability;
            abilities.Add(type, ability);
            Debug.Log("Ability: " + ability.abilityName + " added to dictionary");
        }

        // Initialise key bindings - Yeees this will change.
        keyBindings = new Dictionary<KeyCode, AbilityType>
        {
            { KeyCode.U, AbilityType.Melee },
            { KeyCode.I, AbilityType.Block },
            { KeyCode.O, AbilityType.Dash },
            { KeyCode.P, AbilityType.StrongMeleeAttack },
            { KeyCode.H, AbilityType.ThreeArrowAttack },
            { KeyCode.J, AbilityType.Shield },
            { KeyCode.K, AbilityType.Teleport },
            { KeyCode.L, AbilityType.ExplodingBolt }
        };

        // Conformation in console that array is being populated
        foreach (var ability in abilities.Values)
        {
            Debug.Log("Ability: " + ability.abilityName + " added to array");
        }

        private void Update()
        {
            foreach (var key in keyBindings.Keys)
            {
                if (Input.GetKeyDown(key))
                {
                    ActivateAbility(keyBindings[key], this.gameObject);
                }
            }
        }

        public void ActivateAbility(AbilityType type, GameObject user)
        {
            if (abilities.TryGetValue(type, out Abilities.Ability ability))
            {
                ability.Activate(user);
            }
        }
    }