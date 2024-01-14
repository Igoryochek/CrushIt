using Counter;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using YG;

namespace UI
{
    public class LeaveLevelPanel : MonoBehaviour
    {
        private const float FullSoundValue = 1f;
        private const float ZeroSoundValue = 0f;
        private const int StartSceneNumber = 0;
        private const string Leaderboard = "Leaderboard";

        [SerializeField] private CrystalCounter _crystalCounter;
        [SerializeField] private TextMeshProUGUI _text;

        private int _totalCount;

        private void OnEnable()
        {
            Time.timeScale = ZeroSoundValue;
            _text.text = _crystalCounter.EarnedCrystals.ToString();
        }

        private void OnDisable()
        {
            Time.timeScale = FullSoundValue;
        }

        public void LeaveLevel()
        {
            PlayerPrefs.SetInt(PlayerPrefsKeys.CrystalsCount, _crystalCounter.CrystalsCount);

            if (PlayerPrefs.HasKey(PlayerPrefsKeys.TotalCrystalsCount))
            {
                _totalCount = _crystalCounter.EarnedCrystals + PlayerPrefs.GetInt(PlayerPrefsKeys.TotalCrystalsCount);
                PlayerPrefs.SetInt(PlayerPrefsKeys.TotalCrystalsCount, _totalCount);
            }
            else
            {
                PlayerPrefs.SetInt(PlayerPrefsKeys.TotalCrystalsCount, _crystalCounter.CrystalsCount);
                _totalCount = _crystalCounter.CrystalsCount;
            }

            YandexGame.NewLeaderboardScores(Leaderboard, _totalCount);
            SceneManager.LoadScene(StartSceneNumber);
        }

        public void MultiplyCrystals()
        {
            _crystalCounter.MultyplyEarnedCrystals();
            _text.text = _crystalCounter.EarnedCrystals.ToString();
        }
    }
}

