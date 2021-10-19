using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SortingRender : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] int sortingIndex = 5000;
    [SerializeField] int offset = 0;
    Renderer myRenderer;
    float timer;
    float timerMax = 0.25f;
    [SerializeField] bool runOnce = false;
    void Start()
    {
        timer = timerMax;
        myRenderer = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        timer -= Time.deltaTime;
        if(timer < 0){
            timer = timerMax;
            myRenderer.sortingOrder = (int)(sortingIndex - transform.position.y + offset);
            if(runOnce)
            {
                Destroy(this);
            }
        }
    }
}
