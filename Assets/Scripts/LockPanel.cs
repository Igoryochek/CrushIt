using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LockPanel : MonoBehaviour
{
    [SerializeField] private MenuCrystalCounter _crystalCounter;
    [SerializeField] private TextMeshProUGUI _text;

    private LockButton _currentLockButton;

    public void SetCurrentLockButton(LockButton button)
    {
        _currentLockButton = button;
    }
    public void RemoveLockButton()
    {
        if (_crystalCounter.CrystalsCount >= _currentLockButton.Price)
        {
            _crystalCounter.RemoveCrystals(_currentLockButton.Price);
            PlayerPrefs.SetInt("LockButton" + _currentLockButton.PlanetNumber + "Off", 1);
            _currentLockButton.gameObject.SetActive(false);
            gameObject.SetActive(false);
        }
        else
        {
            _text.gameObject.SetActive(true);
        }
    }
    public void ClosePanel()
    {
        if (_text.gameObject.activeSelf)
        {
            _text.gameObject.SetActive(false);
        }
        gameObject.SetActive(false);
    }
}
