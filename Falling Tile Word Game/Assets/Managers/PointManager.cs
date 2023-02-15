using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PointManager : MonoBehaviour
{
    
    public static PointManager Instance;
    
    private int points;
    private TMP_Text pointsText;
    
    void Awake()
    {
        Instance = this;
        pointsText = GetComponentInChildren<TMP_Text>();
        Reset();
        GameManager.OnGameStateChanged += GameStateChanged;
    }

    private void GameStateChanged(GameState newState)
    {
        if(newState == GameState.Play)
        {
            Reset();
        }
    }

    public void AddPoints(int p)
    {
        points += p;
        UpdateText();
    }

    public void Reset()
    {
        points = 0;
        UpdateText();
    }

    void UpdateText()
    {
        pointsText.text = points.ToString();
    }

}
