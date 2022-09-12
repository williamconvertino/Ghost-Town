using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLightInventory : MonoBehaviour
{

    public GameObject currentLight;
    private void Update()
    {
        if ((Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKeyDown(KeyCode.RightShift)) && currentLight != null)
        {
            GetComponentInChildren<LightObject>().ToggleLight();
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (Input.GetKeyDown(KeyCode.E) && other.CompareTag("LightHolder"))
        {
            LightHolder lightHolderObject = other.GetComponent<LightHolder>();
            
            Destroy(currentLight);
            
            currentLight = lightHolderObject.Pickup();
            currentLight.transform.parent = transform;
            currentLight.transform.localPosition = currentLight.GetComponentInChildren<LightObject>().offset;
        }
    }
}

