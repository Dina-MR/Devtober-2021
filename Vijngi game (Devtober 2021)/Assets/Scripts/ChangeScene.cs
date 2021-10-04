using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR//if in unity editor
using UnityEditor;//use this line
#endif
public class ChangeScene : MonoBehaviour
{
    public void Change()
    {
        SceneManager.LoadScene(1);
    }
    public void Quit()
    {
        #if UNITY_EDITOR
            EditorApplication.ExitPlaymode();//If in editor, quit editor
        #else
            Application.Quit();//Else exit application
        #endif
    }
}
