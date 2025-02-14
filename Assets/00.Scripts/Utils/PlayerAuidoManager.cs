using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAuidoManager : MonoBehaviour
{
    public static PlayerAuidoManager instance;
    [SerializeField] AudioSource _audioSource;
    private void Awake()
    {
        instance = this;
    }

    public void AudioPlay(AudioClip clip)
    {
        _audioSource.PlayOneShot(clip);
    }
}
