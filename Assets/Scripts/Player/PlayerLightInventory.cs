using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLightInventory : MonoBehaviour
{

    public GameObject currentLight;

    private GameObject _activeLightHolder;
    private void Update()
    {
        if ((Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKeyDown(KeyCode.RightShift)) && currentLight != null)
        {
            GetComponentInChildren<LightObject>().ToggleLight();
        }

        if (_activeLightHolder != null && Input.GetKeyDown(KeyCode.E))
        {
            SetLight(_activeLightHolder.GetComponent<LightHolder>().lightPrefab);
            Destroy(_activeLightHolder);
            _activeLightHolder = null;
        }
    }

    void SetLight(GameObject light)
    {
        if (currentLight != null)
        {
            Destroy(currentLight);
        }
        currentLight = Instantiate(light, transform.position, Quaternion.identity, transform);
        currentLight.transform.localPosition = currentLight.GetComponent<LightObject>().offset;
    }
    
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("LightHolder"))
        {
            _activeLightHolder = col.gameObject;
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject == _activeLightHolder)
        {
            _activeLightHolder = null;
        }
    }
}

