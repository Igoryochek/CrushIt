using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using YG;

public class LeaderboardButton : MonoBehaviour
{
    [SerializeField] private GameObject _authorizationPanel;
    [SerializeField] private GameObject _leaderboardPanel;
    [SerializeField] private YandexGame _yandexGame;

    public void Open()
    {
        _yandexGame._AuthorizationCheck();
    }
}
