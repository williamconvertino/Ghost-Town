using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightObject : MonoBehaviour
{
    private GameObject _lightBeam;

    public bool lightOn = false;
    public Vector2 offset = Vector2.zero;
    
    // Start is called before the first frame update
    void Start()
    {
        _lightBeam = transform.GetChild(0).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        _lightBeam.SetActive(lightOn);
    }

    public void ToggleLight ()
    {
        lightOn = !lightOn;
    }

    public void OnPickup()
    {
        transform.localPosition = offset;
    }
}
