using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LetterGridPiece : GridPiece
{
    
    private char letter;
    
    void Start()
    {
        letter = Dictionary.Instance.GetRandomLetter();
        GetComponentInChildren<TMP_Text>().text = letter.ToString();
    }
    
    public override char GetLetter()
    {
        return letter;
    }

}
