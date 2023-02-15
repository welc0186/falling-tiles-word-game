using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameManager : MonoBehaviour
{
    
    public static GameManager Instance;
    public GameState State;
    public static Action<GameState> OnGameStateChanged;

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        UpdateGameState(GameState.TitleMenu);
    }

    public void UpdateGameState(GameState state)
    {
        State = state;
        switch (state) {
            case GameState.Play:
                break;
            case GameState.EndGame:
                break;
            default:
                break;
        }
        OnGameStateChanged?.Invoke(state);
    }
    
}

public enum GameState {
    TitleMenu,
    Play,
    EndGame
}
