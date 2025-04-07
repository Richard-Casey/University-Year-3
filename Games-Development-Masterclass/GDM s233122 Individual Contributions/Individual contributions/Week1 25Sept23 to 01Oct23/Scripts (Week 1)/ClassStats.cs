using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClassStats : MonoBehaviour
{
    public enum ClassStatTypes
    {
        Melee,
        Ranged,
        Count
    }

    public enum StatNames
    {
        AttackDamage,
        RangedDamage,
        Agility,
        ReloadSpeed,
        Range
    }

    public class stat
    {
        ClassStatTypes classtype;
        StatNames name;
        public float value;
        float multiplier;
        int amount;

        public float Multiplier() => multiplier;
        public ClassStatTypes Type() => classtype;
        public int Amount() => amount;

        Func<int,int,float> CalculationMethod;

        public void Multi(float value) => multiplier = value;
        public void AddMulti(float value) => multiplier += value;

        public void AddAmount(int count)
        {
            float Output = (float)CalculationMethod.Invoke(count,amount);
            amount += count;
            value += Output;
        }

        public void Type(ClassStatTypes value) => classtype = value;
        public void Name(StatNames value) => name = value;

        public stat(ClassStatTypes type,StatNames name, float BaseValue, float BaseMultiplier, Func<int,int,float> CalculationMethod)
        {
            this.classtype = type;
            this.name = name;
            this.value = BaseValue;
            this.multiplier = BaseMultiplier;
            this.amount = 0;
            this.CalculationMethod = CalculationMethod;

        }

    }

    List<stat> Stats = new List<stat>();

    public void Start()
    {
        InitStats();
    }


    private void InitStats()
    {

        //Adds a stat with custom calculation function -> idea behind this is reusablility and fuuture balance
        float AttackSum(int i1,int i2) { return (i1 * (1.2f + 1f / MathF.Max(1, i2))); }
        Func<int, int, float> AttackDamageCalculation = AttackSum;
        Stats.Add(new stat(ClassStatTypes.Melee, StatNames.AttackDamage, 1, 1, AttackDamageCalculation));
      
        
        Stats[0].AddAmount(1);
    }


}
