using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioClip _buttonSound;
    [SerializeField] private AudioSource _audioSource;

    private const float FullSoundValue = 1f;
    private const float ZeroSoundValue = 0f;

    public void PlayButtonSound()
    {
        _audioSource.clip = _buttonSound;
        _audioSource.Play();

    }

    public void TurnOnSound()
    {
        AudioListener.volume = FullSoundValue;
    }

    public void TurnOffSound()
    {
        AudioListener.volume = ZeroSoundValue;
    }
}
