using UnityEngine;
using YG;

public class Authorization : MonoBehaviour
{
    [SerializeField] private LeaderboardButton _leaderboardButton;

    public void Authorize()
    {
        YandexGame.AuthDialog();
    }

    public void SetNoNeedAuthorization()
    {
        _leaderboardButton.gameObject.SetActive(false);
    }
}
