using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;

public class LetterToken : MonoBehaviour, ICanBeHeld, IHaveLetter
{

    public bool BeingHeld { get; private set; }
    public event EventHandler<EventArgs> OnLetterTokenCleared;
    private TokenTray tokenTray;
    private char letter;

    void Awake()
    {
        GetComponent<DragDrop>().OnDragStateChanged += OnDragStateChanged;
        BeingHeld = false;
        tokenTray = GetComponentInParent<TokenTray>();
        GameManager.OnGameStateChanged += GameStateChanged;
    }

    void Start()
    {
        letter = Dictionary.Instance.GetRandomLetter();
        GetComponentInChildren<TMP_Text>().text = letter.ToString();
    }

    void OnDragStateChanged(object sender, DragDrop.OnDragStateChangedEventArgs args)
    {
        if(!args.beingDragged)
        {
            CheckForHolder();
        }
    }

    private void GameStateChanged(GameState newState)
    {
        Destroy(this.gameObject);
    }

    void OnDestroy()
    {
        GetComponent<DragDrop>().OnDragStateChanged -= OnDragStateChanged;
        GameManager.OnGameStateChanged -= GameStateChanged;
    }

    void CheckForHolder()
    {
        RaycastHit2D[] hits = Physics2D.RaycastAll(this.transform.position, Vector2.left, (float) 0.0001);
        foreach(RaycastHit2D hit in hits)
        {
            if(hit.transform.gameObject.GetComponent<ICanHold>() != null)
            {
                hit.transform.gameObject.GetComponent<ICanHold>().Hold(this.gameObject);
                return;
            }
        }
        this.transform.SetParent(tokenTray.transform);
    }

    public void MoveTo(Vector3 position)
    {
        if(!GetComponent<DragDrop>().BeingDragged && (position - this.transform.position).magnitude > 0.01f)
        {
            //this.transform.position = position;
            transform.DOMove(position, 0.15f);
        }
    }

    public char GetLetter()
    {
        return letter;
    }

    public void Clear()
    {
        PointManager.Instance.AddPoints(1);
        OnLetterTokenCleared?.Invoke(this, EventArgs.Empty);
        Destroy(this.gameObject);
    }
}
