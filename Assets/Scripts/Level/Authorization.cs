using UI;
using UnityEngine;
using YG;

namespace Level
{
    public class Authorization : MonoBehaviour
    {
        [SerializeField] private LeaderboardButton _leaderboardButton;

        public void Authorize()
        {
            YandexGame.AuthDialog();
        }

        public void TurnOffLeaderBoardButton()
        {
            _leaderboardButton.gameObject.SetActive(false);
        }
    }
}