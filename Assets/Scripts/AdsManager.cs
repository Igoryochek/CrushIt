using UnityEngine;
using YG;

public class AdsManager : MonoBehaviour
{
    [SerializeField] private AudioManager _audioManager;

    public void ShowInterstitialAd()
    {
        YandexGame.RewVideoShow(0);
        StopGame();
    }

    public void StopGame()
    {
        Time.timeScale = 0;
        _audioManager.TurnOffSound();
    }

    public void PlayGame()
    {
        Time.timeScale = 1;
        _audioManager.TurnOnSound();
    }
}
