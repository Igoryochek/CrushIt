using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using YG;

public class LeaveLevelPanel : MonoBehaviour
{
    [SerializeField] private CrystalCounter _crystalCounter;
    [SerializeField] private TextMeshProUGUI _text;

    private int _totalCount;

    private void OnEnable()
    {
        Time.timeScale = 0;
        _text.text = _crystalCounter.EarnedCrystals.ToString();
    }

    private void OnDisable()
    {
        Time.timeScale = 1;
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
        YandexGame.NewLeaderboardScores("Leaderboard",_totalCount);
        SceneManager.LoadScene(0);
    }

    public void MultiplyCrystals()
    {
        _crystalCounter.MultyplyEarnedCrystals();
        Debug.Log(_crystalCounter.EarnedCrystals);
        _text.text = _crystalCounter.EarnedCrystals.ToString();
    }
}
