using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class levelLighting : MonoBehaviour
{
    public bool levelNotCleared { get; set; } = true;
 


    void Update()
    {
        gameObject.SetActive(levelNotCleared);
    }
}
