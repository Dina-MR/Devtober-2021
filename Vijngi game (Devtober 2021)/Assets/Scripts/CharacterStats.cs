using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CharacterStats : MonoBehaviour
{
    //[SerializeField] public Stat level;

    //[SerializeField] public Stat attack;
    //[SerializeField] public Stat defense;
    //[SerializeField] public Stat hp;
    //[SerializeField] public Stat tp;
    //[SerializeField] public Stat criticalChance;
    //[SerializeField] public Stat criticalAttack;

    public List<Stat> stats = new List<Stat>();

    void Start(float attackValue, float defenseValue, float hpValue, float tpValue, float criticalChanceValue, float criticalAttackValue)
    {
        stats.Add(new Stat(attackValue, "Attack", "ATK"));
        stats.Add(new Stat(defenseValue, "Defense", "DEF"));
        stats.Add(new Stat(hpValue, "HP", "HP"));
        stats.Add(new Stat(tpValue, "TP", "TP"));
        stats.Add(new Stat(criticalChanceValue, "Critical Chance", "CRIT.CHA"));
        stats.Add(new Stat(criticalAttackValue, "Critical Attack", "CRIT.ATK"));
    }

    public void CharacterStatsFunction()
    {
        //
    }

    // Represents a stat
    public class Stat
    {
        public float baseValue { get; set; } //Represents the stat value at Level 1;
        public float currentValue { get; set; } //Represents the current value of the stat
        public string statName { get; set; }
        public string statAbbreviation { get; set; }
        private List<StatModifier> statModifiers; //Lists the buffs and debuffs on the stat

        public Stat(float _baseValue, string _statName, string _statAbbreviation)
        {
            this.baseValue = _baseValue;
            this.statName = _statName;
            this.statAbbreviation = statAbbreviation;
        }

        public void AddStatModifier(StatModifier statModifier)
        {
            this.statModifiers.Add(statModifier);
        }

        public void RemoveStatModifier(StatModifier statModifier)
        {
            this.statModifiers.Remove(statModifier);
        }

        public float GetCalculatedStatValue()
        {
            float newValue = this.baseValue + this.statModifiers.Sum(statModifier => statModifier.modifierValue); // Calculate the current value by adding to the base value the total of the modifiers values
            return newValue;
        }
    }

    // Represent buffs or debuffs on the stat
    public class StatModifier
    {
        public float modifierValue { get; set; }

        public StatModifier(float _modifierValue)
        {
            modifierValue = _modifierValue;
        }
    }
}
