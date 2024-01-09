using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using YG;

public class LeaveLevelPanel : MonoBehaviour
{
    [SerializeField] private CrystalCounter _crystalCounter;
    [SerializeField] private TextMeshProUGUI _text;

    private int _totalCount;

    private const float FullSoundValue = 1f;
    private const float ZeroSoundValue = 0f;

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
        PlayerPrefs.SetInt("CrystalsCount", _crystalCounter.CrystalsCount);

        if (PlayerPrefs.HasKey("TotalCrystalsCount"))
        {
            _totalCount = _crystalCounter.EarnedCrystals + PlayerPrefs.GetInt("TotalCrystalsCount");
            PlayerPrefs.SetInt("TotalCrystalsCount", _totalCount);
        }
        else
        {
            PlayerPrefs.SetInt("TotalCrystalsCount", _crystalCounter.CrystalsCount);
            _totalCount = _crystalCounter.CrystalsCount;
        }

        YandexGame.NewLeaderboardScores("Leaderboard", _totalCount);
        SceneManager.LoadScene(0);
    }

    public void MultiplyCrystals()
    {
        _crystalCounter.MultyplyEarnedCrystals();
        _text.text = _crystalCounter.EarnedCrystals.ToString();
    }
}
