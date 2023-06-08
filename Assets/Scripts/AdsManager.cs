using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using YG;

public class AdsManager : MonoBehaviour
{
    [SerializeField]private AudioManager _audioManager;

    public void ShowFirstAd()
    {
        YandexGame.RewVideoShow(0);
        StopGame();
    }
    
    public void ShowSecondAd()
    {
        YandexGame.RewVideoShow(1);
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
