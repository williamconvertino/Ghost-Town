using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuNavigation : MonoBehaviour
{
    public Button startButton;
    public Button levelSelectButton;

    // Start is called before the first frame update
    void Start()
    {
        startButton.onClick.AddListener(StartGame);
        levelSelectButton.onClick.AddListener(SelectLevel);
    }

    void StartGame()
    {
        GameState.LoadLevel(1);
    }

    void SelectLevel()
    {
        GameState.LoadLevelSelect();
    }
}
