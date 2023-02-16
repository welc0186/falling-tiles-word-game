using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;

public class LetterToken : Token, IHaveLetter
{

    public event EventHandler<EventArgs> OnLetterTokenCleared;
    private char letter;

    void Start()
    {
        letter = Dictionary.Instance.GetRandomLetter();
        GetComponentInChildren<TMP_Text>().text = letter.ToString();
    }

    public char GetLetter()
    {
        return letter;
    }

}
