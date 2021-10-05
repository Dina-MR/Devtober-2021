using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    bool paused = false;
    GameObject image;
    GameObject text;
    void Start()
    {
        image = GetChildWithName(gameObject, "Image");
        text = GetChildWithName(gameObject, "PauseText");
    }
    public void PauseGame()
    {
        if(paused)
        {
            Time.timeScale = 1;
            paused = false;
            image.SetActive(false);
            text.SetActive(false);
        }else
        {
            Time.timeScale = 0;
            paused = true;
            image.SetActive(true);
            text.SetActive(true);
        }
    }
    GameObject GetChildWithName(GameObject obj, string name) 
    {
        Transform trans = obj.transform;
        Transform childTrans = trans. Find(name);
        if (childTrans != null) 
        {
            return childTrans.gameObject;
        }else
        {
            Debug.Log("No child found");
            return null;
        }
    }
}
