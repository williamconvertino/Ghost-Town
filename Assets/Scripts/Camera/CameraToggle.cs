using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraToggle : MonoBehaviour
{
    private Camera[] _cameras;
    private int _cameraIndex = 0;
    private void Start()
    {
        _cameras = Camera.allCameras;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            ToggleCamera();
        }
    }

    private void ToggleCamera()
    {
        if (_cameras.Length < 1)
        {
            return;
        }

        _cameraIndex = (_cameraIndex + 1) % _cameras.Length;
        for (int i = 0; i < _cameras.Length; i++)
        {
            if (i == _cameraIndex)
            {
                _cameras[i].enabled = true;
            }
            else
            {
                _cameras[i].enabled = false;
            }
        }
    }
    
    
}
