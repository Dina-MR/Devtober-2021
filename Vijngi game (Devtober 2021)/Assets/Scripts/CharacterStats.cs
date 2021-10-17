using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStats : MonoBehaviour
{
    [SerializeField] public Stat level;

    [SerializeField] public Stat attack;
    [SerializeField] public Stat defense;
    [SerializeField] public Stat hp;
    [SerializeField] public Stat tp;
    [SerializeField] public Stat criticalChance;
    [SerializeField] public Stat criticalAttack;

    public CharacterStats()
    {
        //
    }

    // Represents a stat
    public class Stat
    {
        public float baseValue; //Represents the stat value at Level 1;
        public float currentValue;
        public float minimalValue;
        public float maximalValue;
        public float increaseValue; // Increases the value of the stat after leveling up

        public Start(float _baseValue, float _currentValue, float _minimalValue, float _maximalValue, float _increaseValue)
        {
            this.baseValue = _baseValue;
            this.currentValue = _currentValue;
            this.minimalValue = _minimalValue;
            this.maximalValue = _maximalValue;
            this.increaseValue = _increaseValue;
        }
    }
}
