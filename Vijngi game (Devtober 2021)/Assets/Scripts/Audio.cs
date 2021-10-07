using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Audio : MonoBehaviour
{
    // Start is called before the first frame update
    public static Audio instance{get; private set;}
    private static AudioSource sound;
    void Start()
    {
        sound = GetComponent<AudioSource>();
    }
    void Update()
    {
        if(SceneManager.GetActiveScene().name == "SampleScene")
        {
            sound.Stop();
        }
    }

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
