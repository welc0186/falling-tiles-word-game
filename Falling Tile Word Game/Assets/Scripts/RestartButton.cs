using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RestartButton : MonoBehaviour
{

    void Awake()
    {
        GetComponent<Button>().onClick.AddListener(RestartButtonClicked);
    }
    
    void RestartButtonClicked()
    {
        GameManager.Instance.UpdateGameState(GameState.Play);
        GetComponent<SoundClip>()?.PlayClip();
    }

}
