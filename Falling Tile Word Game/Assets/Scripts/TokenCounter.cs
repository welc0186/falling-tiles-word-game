using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TokenCounter : MonoBehaviour
{
    [SerializeField] private int startingTokens;

    public int TokensRemaining { get; private set; }
    private TMP_Text displayText;

    void Awake()
    {
        displayText = GetComponent<TMP_Text>();
        TokensRemaining = startingTokens;
        UpdateDisplay();
    }
    
    public void AddTokens(int tokens)
    {
        TokensRemaining += tokens;
        UpdateDisplay();
    }

    void UpdateDisplay()
    {
        displayText.text = TokensRemaining.ToString();
    }

    public void Reset()
    {
        TokensRemaining = startingTokens;
        UpdateDisplay();
    }

}
