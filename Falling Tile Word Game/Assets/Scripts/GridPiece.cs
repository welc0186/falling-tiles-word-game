using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class GridPiece : MonoBehaviour
{

    public event EventHandler<OnGridChangedEventArgs> OnGridChanged;
    public class OnGridChangedEventArgs : EventArgs {
        public GameObject GridPiece;
    }
    
    void Awake()
    {
        GameManager.OnGameStateChanged += GameStateChanged;
    }

    public virtual void GridChanged()
    {
        OnGridChanged?.Invoke(this, new OnGridChangedEventArgs{GridPiece = this.gameObject});
    }

    private void GameStateChanged(GameState newState)
    {
        Destroy(this.gameObject);
    }

    void OnDestroy()
    {
        GameManager.OnGameStateChanged -= GameStateChanged;
    }

}
