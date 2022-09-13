using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RestartNavigation : MonoBehaviour
{
    public Button restartLevelButton;
    public Button returnToMenuButton;

    // Start is called before the first frame update
    void Start()
    {
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

}
