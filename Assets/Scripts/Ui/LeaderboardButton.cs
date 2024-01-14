using UnityEngine;
using YG;

namespace UI
{
    public class LeaderboardButton : MonoBehaviour
    {
        [SerializeField] private YandexGame _yandexGame;

        public void Open()
        {
            _yandexGame._RequestAuth();
        }
    }
}

