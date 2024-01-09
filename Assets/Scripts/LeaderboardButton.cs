using UnityEngine;
using YG;

public class LeaderboardButton : MonoBehaviour
{
    [SerializeField] private YandexGame _yandexGame;

    public void Open()
    {
        _yandexGame._RequestAuth();
    }
}
