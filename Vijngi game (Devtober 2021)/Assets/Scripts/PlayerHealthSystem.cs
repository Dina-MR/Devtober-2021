using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthSystem : MonoBehaviour
{
    public const int MAX_FRAGMENT_AMOUNT = 2;

    public event EventHandler OnDamaged;
    public event EventHandler OnHealed;
    public event EventHandler OnDead;
    public int numberOfHearts; // Maximum number of hearts
    public int maxHealth; // Maximum HP
    public int currentHealth; // Current HP

    private List<Heart> heartList;

    void Start()
    {
        //Gets the hp stat from the Player's character stats component
        maxHealth = (int)GetComponent<CharacterStats>().hpValue;
        currentHealth = maxHealth;
        //Sets the number of hearts based on the max health
        switch(maxHealth % MAX_FRAGMENT_AMOUNT == 0)
        {
            case true:
                numberOfHearts = maxHealth / MAX_FRAGMENT_AMOUNT;
                break;
            default:
                numberOfHearts = (maxHealth + 1) / MAX_FRAGMENT_AMOUNT;
                break;
        }
        //Initialize the hearts list
        heartList = new List<Heart>();
        //Initialize each heart's fragments number, except the last
        for (int i = 0; i < numberOfHearts - 1; i++)
        {
            heartList.Add(new Heart(MAX_FRAGMENT_AMOUNT));
        }
        //Initialize the last heart's fragments number
        switch(maxHealth % MAX_FRAGMENT_AMOUNT == 0)
        {
            case true:
                heartList.Add(new Heart(MAX_FRAGMENT_AMOUNT));
                break;
            default:
                heartList.Add(new Heart(numberOfHearts * MAX_FRAGMENT_AMOUNT - maxHealth));
                break;
        }
    }

    /*
    public PlayerHealthSystem(int numberOfHearts)
    {
        heartList = new List<Heart>();
        for (int i = 0; i < numberOfHearts; i++)
        {
            heartList.Add(new Heart(2));
        }
        SetMaxHealth(numberOfHearts * MAX_FRAGMENT_AMOUNT);
        SetCurrentHealth(maxHealth);
    }*/

    public void SetMaxHealth(int maxHealth)
    {
        this.maxHealth = maxHealth;
    }
    public int GetMaxHealth()
    {
        return this.maxHealth;
    }

    public void SetCurrentHealth(int currentHealth)
    {
        this.currentHealth = currentHealth;
    }
    public int GetCurrentHealth()
    {
        return this.currentHealth;
    }

    public List<Heart> GetHeartList()
    {
        return this.heartList;
    }

    //Increse the maximum health
    public void UpgradeMaxHealth()
    {
        maxHealth += 2;
        AddNewHeart();
    }

    //Increase the maximum number of hearts by one 
    public void AddNewHeart()
    {
        Heart newHeart = new Heart(2);
        numberOfHearts++;
        heartList.Add(newHeart);
    }

    public void Damage(int damage)
    {
        SetCurrentHealth(Math.Max(0, currentHealth -= damage));
        Debug.Log("Damaged : " + currentHealth);
        //decimal currentHealthDecimal = Convert.ToDecimal(currentHealth);
        //int lastDamagedHeartIndex = Decimal.ToInt32(Math.Round(Decimal.Divide(currentHealthDecimal, 2m), 0, MidpointRounding.AwayFromZero)) - 1;
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

        if(this.OnDamaged != null) OnDamaged(this, EventArgs.Empty);

        if(isDead())
        {
            if(this.OnDead != null) OnDead(this, EventArgs.Empty);
        }
    }

    public void Heal(int heal)
    {
        SetCurrentHealth(Math.Min(maxHealth, currentHealth += heal));
        Debug.Log("Healing : " + currentHealth);
        //decimal currentHealthDecimal = Convert.ToDecimal(currentHealth);
        //int firstHealedHeartIndex = Decimal.ToInt32(Math.Round(Decimal.Divide(currentHealthDecimal, 2m), 0, MidpointRounding.AwayFromZero)) - 1;
        for (int i = 0; i < heartList.Count; i++)
        {
            Heart heart = heartList[i];
            int missingFragments = MAX_FRAGMENT_AMOUNT - heart.GetFragmentAmount();
            if(heal > missingFragments)
            {
                heal -= missingFragments;
                heart.Heal(missingFragments);
            }
            else
            {
                heart.Heal(heal);
                break;
            }
        }

        if(this.OnHealed != null) OnHealed(this, EventArgs.Empty);
    }

    public bool isDead()
    {
        return currentHealth == 0;
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

        public void Heal(int heal)
        {
            switch(fragments + heal > MAX_FRAGMENT_AMOUNT)
            {
                case true:
                    fragments = MAX_FRAGMENT_AMOUNT;
                    break;
                default:
                    fragments += heal;
                    break;
            }
        }
    }
}
