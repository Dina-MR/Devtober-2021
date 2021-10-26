using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CharacterStats : MonoBehaviour
{
    public List<Stat> stats = new List<Stat>();
    public float attackValue;
    public float defenseValue;
    public float hpValue;
    public float tpValue;
    public float criticalChanceValue;
    public float criticalAttackValue;

    public void Start()
    {
        //Adds all stats to the list
        stats.Add(new Stat(attackValue, "Attack", "ATK"));
        stats.Add(new Stat(defenseValue, "Defense", "DEF"));
        stats.Add(new Stat(hpValue, "HP", "HP"));
        stats.Add(new Stat(tpValue, "TP", "TP"));
        stats.Add(new Stat(criticalChanceValue, "Critical Chance", "CRIT.CHA"));
        stats.Add(new Stat(criticalAttackValue, "Critical Attack", "CRIT.ATK"));
    }

    // Represents a stat
    public class Stat
    {
        public float baseValue { get; set; } //Represents the pure stat value, without any modifiers applied
        public float currentValue { get; set; } //Represents the current value of the stat, whenever or not a modifier is applied
        public string statName { get; set; }
        public string statAbbreviation { get; set; }
        private List<StatModifier> statModifiers; //Lists the buffs and debuffs on the stat

        public Stat(float _baseValue, string _statName, string _statAbbreviation)
        {
            this.baseValue = _baseValue;
            this.currentValue = _baseValue;
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
