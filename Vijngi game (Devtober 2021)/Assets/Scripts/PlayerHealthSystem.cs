using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthSystem : MonoBehaviour
{
    public event EventHandler OnDamaged;
    public int numberOfHearts;

    private List<Heart> heartList;

    /*void Start()
    {
        currentHealth = maxHealth;
    }

    void Update()
    {
        
    }*/

    public PlayerHealthSystem(int numberOfHearts)
    {
        heartList = new List<Heart>();
        for (int i = 0; i < numberOfHearts; i++)
        {
            heartList.Add(new Heart(4));
        }
    }

    public List<Heart> GetHeartList()
    {
        return this.heartList;
    }


    public void Damage(int damage)
    {
        // Checks how much damage each heart can take, then decreases their fragments value
        for (int i = heartList.Count -1; i >= 0; i--)
        {
            Heart heart = heartList[i];
            // If the damage is higher than the value of each heart fragments
            if(damage > heart.GetFragmentAmount()) 
            {
                damage -= heart.GetFragmentAmount();
                heart.Damage(heart.GetFragmentAmount());
            }
            // When the last heart receives damage
            else
            {
                heart.Damage(damage);
                break;
            }
        }

        if(OnDamaged != null) OnDamaged(this, EventArgs.Empty);
    }

    // Represents a heart
    public class Heart
    {
        // Represents the amount of HP inside a heart (0: empty, 1: half-full, 2: full)
        private int fragments;

        public Heart(int fragments)
        {
            this.fragments = fragments;
        }

        public int GetFragmentAmount()
        {
            return fragments;
        }

        public void SetFragments(int fragments)
        {
            this.fragments = fragments;
        }

        public void Damage(int damage)
        {
            switch(damage > fragments)
            {
                case true:
                    fragments = 0;
                    break;
                default:
                    fragments -= damage;
                    break;
            }
        }
    }
}
