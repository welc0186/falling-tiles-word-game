using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundClip : MonoBehaviour
{
    [SerializeField] private AudioClip clip;

    public void PlayClip()
    {
        SoundManager.Instance.PlaySound(clip);
    }
}
