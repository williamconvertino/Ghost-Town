using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class GameState
{
    public static int currentLevel = 0;
    public static State currentState = State.MainMenu;

    public enum State
    {
        MainMenu,
        EscapeMenu,
        Level,
        LevelSelect
    }

    public static void LoadNextLevel()
    {
        if (currentLevel == 5)
        {
            SceneManager.LoadScene("MainMenu");
        }
        LoadLevel(currentLevel + 1);
    }
    
    public static void LoadLevel(int level)
    {
        SceneManager.LoadScene("Level" + level);
        currentLevel = level;
        currentState = State.Level;
    }

    public static void LoadMenu()
    {
        currentLevel = 0;
        currentState = State.MainMenu;
    }

    public static void LoadLevelSelect()
    {
        currentLevel = 0;
        currentState = State.LevelSelect;
    }

}
