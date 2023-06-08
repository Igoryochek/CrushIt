using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioClip _buttonSound;
    [SerializeField] private AudioSource _audioSource;

    public void PlayButtonSound()
    {
        _audioSource.clip = _buttonSound;
        _audioSource.Play();
        
    }
    public void TurnOnSound()
    {
        AudioListener.volume = 1;
    }

    public void TurnOffSound()
    {
        AudioListener.volume = 0;

    }
}
