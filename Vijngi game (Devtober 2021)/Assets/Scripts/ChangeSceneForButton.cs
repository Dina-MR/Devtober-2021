using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeSceneForButton : MonoBehaviour
{
    [SerializeField] int index;
    public void ChangeScene()
    {
        SceneManager.LoadScene(index);
    }
}
