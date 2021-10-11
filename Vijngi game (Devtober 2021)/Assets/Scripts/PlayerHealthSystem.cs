using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthSystem : MonoBehaviour
{
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


    /*public void TakeDamage(float damage)
    {
        currentHealth -= damage;
    }*/

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
    }
}
