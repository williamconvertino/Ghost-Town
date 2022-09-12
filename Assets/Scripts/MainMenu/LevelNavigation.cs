using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelNavigation : MonoBehaviour
{
    public string scene;

    private Button button;
    // Start is called before the first frame update
    void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(SelectLevel);
    }

    void SelectLevel()
    {
        SceneManager.LoadScene(scene);
    }
}
