using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    
    [SerializeField] private AudioSource musicSource, effectsSource;
    
    public static SoundManager Instance;

    void Awake()
    {
        Instance = this;
    }

    public void PlaySound(AudioClip clip)
    {
        effectsSource.PlayOneShot(clip);
    }
}
