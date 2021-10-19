using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectPlayer : MonoBehaviour
{
    Dialogue dialogue;
    [SerializeField] GameObject thoughtBubble;
    void Start()
    {
        dialogue = GetComponent<Dialogue>();
    }    
    void OnTriggerStay2D(Collider2D other)
    {
        if(!dialogue.getConversation && Input.GetKeyDown(KeyCode.E))
        {
            StartCoroutine(dialogue.Type());
            dialogue.getConversation = true;
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        thoughtBubble.SetActive(true);
    }
    void OnTriggerExit2D(Collider2D other)
    {
        thoughtBubble.SetActive(false);
    }
}
