using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LetterTokenSpawner : MonoBehaviour
{
    
    [SerializeField] private GameObject letterTokenPrefab;
    [SerializeField] private int numberLetterTokens;

    private TokenCounter tokenCounter;
    
    void Awake()
    {
        tokenCounter = GetComponentInChildren<TokenCounter>();
        GameManager.OnGameStateChanged += GameStateChanged;
    }

    void OnDestroy()
    {
        GameManager.OnGameStateChanged -= GameStateChanged;
    }

    void Initialize()
    {
        tokenCounter.Reset();
        for(int i = 0; i < numberLetterTokens; i++)
        {
            SpawnLetterToken();
        }
    }

    private void GameStateChanged(GameState newState)
    {
        if(newState == GameState.Play)
        {
            Initialize();
        }
    }

    void SpawnLetterToken()
    {
        if(tokenCounter.TokensRemaining > 0)
        {
            LetterToken letterToken = Instantiate(letterTokenPrefab, this.transform).GetComponent<LetterToken>();
            letterToken.OnLetterTokenCleared += LetterTokenCleared;
            tokenCounter.AddTokens(-1);
        } else {
            GameManager.Instance.UpdateGameState(GameState.EndGame);
        }
    }

    void LetterTokenCleared(object sender, EventArgs e)
    {
        SpawnLetterToken();
    } 

}
