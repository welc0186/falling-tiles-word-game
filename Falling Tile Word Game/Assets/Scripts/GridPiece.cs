using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class GridPiece : MonoBehaviour, IHaveLetter
{

    public event EventHandler<OnGridChangedEventArgs> OnGridChanged;
    public class OnGridChangedEventArgs : EventArgs {
        public GameObject GridPiece;
    }
    
    void Awake()
    {
        GameManager.OnGameStateChanged += GameStateChanged;
    }
    
    public virtual char GetLetter()
    {
        return ' ';
    }

    public virtual void Clear()
    {
        Destroy(this.gameObject);
    }

    public virtual void GridChanged()
    {
        OnGridChanged?.Invoke(this, new OnGridChangedEventArgs{GridPiece = this.gameObject});
    }

    private void GameStateChanged(GameState newState)
    {
        Destroy(this.gameObject);
    }

    public void Fall()
    {
        Vector3 newPosition = new Vector3(
            this.transform.position.x,
            this.transform.position.y - 1,
            0
        );
        transform.DOMove(newPosition, 0.5f);
        transform.position = newPosition;
    }

    void OnDestroy()
    {
        GameManager.OnGameStateChanged -= GameStateChanged;
    }

    public void FallTo(Vector3 vector3)
    {
        transform.DOMove(vector3, 0.5f);
    }
}
