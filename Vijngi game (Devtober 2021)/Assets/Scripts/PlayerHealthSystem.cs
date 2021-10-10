using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public float maxHealth = 3;
    public float currentHealth;
    public int numberOfHearts;

    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite halfHeart;
    public Sprite emptyHeart;

    void Start()
    {
        currentHealth = maxHealth;
    }

    void Update()
    {
        for(int i = 0; i < hearts.Length; i++)
        {
            if(i < currentHealth){
                hearts[i].sprite = fullHeart;
            }

            switch(i < numberOfHearts)
            {
                case true:
                    hearts[i].enabled = true;
                    break;
                default:
                    hearts[i].enabled = false;
                    break;
            }
        }
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        // When the player's new health value ends with .5
        //if(currentHealth * 10 % 10 != 10)
        //{
            //for(int i = 0; i < currentHealth + damage - .5; i++)
        //}
    }
}
