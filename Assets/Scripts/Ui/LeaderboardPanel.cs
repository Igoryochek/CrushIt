using UnityEngine;
using YG;

namespace UI
{
    public class LeaderboardPanel : MonoBehaviour
    {
        [SerializeField] private LeaderboardYG _leaderboard;

        private void OnEnable()
        {
            _leaderboard.UpdateLB();
        }
    }
}