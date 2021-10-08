using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundControl : MonoBehaviour
{
    // Start is called before the first frame update
    Slider slider;
    AudioSource sound;
    float value;
    void Start()
    {
        slider = GetComponent<Slider>();
        sound = GameObject.Find("ThemeSong").GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        sound.volume = slider.value;
    }
}
