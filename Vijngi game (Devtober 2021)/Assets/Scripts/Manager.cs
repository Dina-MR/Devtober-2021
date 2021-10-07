using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{//This is a singleton pattern
//will create an instance of the manager throughout the whole game 
// there can only be one instance
    public static Manager instance{get; private set;}

    void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }else
        {
            Destroy(gameObject);
        }
    }
}
