using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lightSwitch : MonoBehaviour
{
    public GameObject lightBulb;
    public bool levelWon = false;
    public GameObject levelSpotlight;
    public GameObject levelMask;
    // Start is called before the first frame update

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("lightBulb"))
            {
            levelWon = true;
            levelSpotlight.SetActive(!levelWon);
            levelMask.SetActive(levelWon);
        }
    }
}
