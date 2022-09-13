using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RestartNavigation : MonoBehaviour
{
    public Button restartLevelButton;
    public Button returnToMenuButton;
    public AudioClip audioClip;

    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = audioClip;
        StartCoroutine(PlayScream());
        restartLevelButton.onClick.AddListener(Restart);
        returnToMenuButton.onClick.AddListener(ReturnToMenu);
    }

    void Restart()
    {
        GameState.LoadCurrentLevel();
    }

    void ReturnToMenu()
    {
        GameState.LoadLevelSelect();
    }

    IEnumerator PlayScream()
    {
        audioSource.Play();
        yield return (new WaitForSeconds(0.5f));
        audioSource.Stop();
    }

}
