using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour
{
    public static GameState CurrentGameState;

    public int currentLevel = 0;
    public State currentState = State.MainMenu;
    
    public enum State
    {
        MainMenu,
        EscapeMenu,
        InLevel,
        InLevelSelect
    }

    private void Awake()
    {
        if (CurrentGameState == null)
        {
            DontDestroyOnLoad(gameObject);
            CurrentGameState = this;   
        }
        else
        {
            Destroy(gameObject);
        }
    }

    
    private void LoadNextLevel()
    {
        LoadLevel(currentLevel + 1);
    }
    
    private void LoadLevel(int level)
    {
        currentLevel = level;
        currentState = State.InLevel;
    }
    
}
