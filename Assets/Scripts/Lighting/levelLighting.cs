using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class levelLighting : MonoBehaviour
{
    public bool levelNotCleared { get; set; } = true;
    // Start is called before the first frame update
    // Update is called once per frame


    void Update()
    {
        gameObject.SetActive(levelNotCleared);
    }
}
