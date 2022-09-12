using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightHolder : MonoBehaviour
{
    public GameObject lightPrefab;
    private GameObject _lightDisplay;
    
    // Start is called before the first frame update
    void Start()
    {
        _lightDisplay = Instantiate(lightPrefab, transform.position, Quaternion.identity, transform);
    }

    // Update is called once per frame
    public GameObject Pickup()
    {
        return _lightDisplay;
    }
}
