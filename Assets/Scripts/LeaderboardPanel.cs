using UnityEngine;
using YG;

public class LeaderboardPanel : MonoBehaviour
{
    [SerializeField] private LeaderboardYG _leaderboard;

    private void OnEnable()
    {
        _leaderboard.UpdateLB();
    }
}
