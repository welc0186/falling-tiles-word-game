using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MenuManager : MonoBehaviour
{
    
    [SerializeField] private GameObject startMenu;
    [SerializeField] private GameObject endGameMenu;
    public static MenuManager Instance;

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        GameManager.OnGameStateChanged += GameStateChanged;
    }

    void OnDestroy()
    {
        GameManager.OnGameStateChanged -= GameStateChanged;
    }

    private void GameStateChanged(GameState newState)
    {
        startMenu.SetActive(newState == GameState.TitleMenu);
        endGameMenu.SetActive(newState == GameState.EndGame);
    }
}
