using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightObject : MonoBehaviour
{
    private GameObject _lightBeam;

    public bool lightOn = false;
    public Vector2 offset = Vector2.zero;

    public AudioClip audioClip;

    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.AddComponent<AudioSource>();
        audioSource = GetComponent<AudioSource>();
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
        StartCoroutine(PlaySwitchSound());
    }

    public void OnPickup()
    {
        transform.localPosition = offset;
    }

    private IEnumerator PlaySwitchSound()
    {
        audioSource.clip = audioClip;
        audioSource.pitch = 3;
        audioSource.Play();
        yield return new WaitForSeconds(0.3f);
        audioSource.Stop();
    }
}
