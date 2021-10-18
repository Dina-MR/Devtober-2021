using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SortingRender : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] int sortingIndex = 5000;
    [SerializeField] int offset = 0;
    Renderer myRenderer;
    void Start()
    {
        myRenderer = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        myRenderer.sortingOrder = (int)(sortingIndex - transform.position.y + offset);
    }
}
