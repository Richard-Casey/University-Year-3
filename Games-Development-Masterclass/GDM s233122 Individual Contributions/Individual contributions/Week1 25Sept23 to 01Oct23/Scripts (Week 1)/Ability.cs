using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Abilities/Ability")]
public abstract class Ability : ScriptableObject
{
    public string abilityName;
    public float cooldown;
    public float duration;

    public abstract void Activate(GameObject user);
}
