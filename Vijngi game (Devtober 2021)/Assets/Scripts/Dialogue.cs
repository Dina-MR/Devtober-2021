using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Dialogue : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] TextMeshProUGUI textDisplay;
    [SerializeField] string[] sentences;
    [SerializeField] float typingSpeed = 0.1f;
    int index;
    public GameObject continueText;
    bool inConversation = false;
    public bool test = false;
    public bool getConversation
    {
        get { return inConversation; }
        set { inConversation = value; }
    }
    void Update()
    {
        if(textDisplay.text == sentences[index])
        {
            continueText.SetActive(true);
            if(Input.GetKeyDown(KeyCode.E))
            {
                NextSentence();
            }
        }
    }
    public IEnumerator Type()
    {
        foreach(char letter in sentences[index].ToCharArray())
        {
            textDisplay.text += letter;
            yield return new WaitForSeconds(typingSpeed); 
        }
    }
    public void NextSentence()
    {
        continueText.SetActive(false);
        if(index < sentences.Length - 1)
        {
            index++;
            textDisplay.text = "";
            StartCoroutine(Type());
        }else
        {
            textDisplay.text = "";
            continueText.SetActive(false);
            inConversation = false;
            index = 0;
        }
    }
}
