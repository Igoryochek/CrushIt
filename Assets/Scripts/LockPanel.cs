using TMPro;
using UnityEngine;

public class LockPanel : MonoBehaviour
{
    [SerializeField] private MenuCrystalCounter _crystalCounter;
    [SerializeField] private TextMeshProUGUI _text;

    private LockButton _currentLockButton;
    private const int One = 1;

    public void SetCurrentLockButton(LockButton button)
    {
        _currentLockButton = button;
    }

    public void RemoveLockButton()
    {
        if (_crystalCounter.CrystalsCount >= _currentLockButton.Price)
        {
            _crystalCounter.RemoveCrystals(_currentLockButton.Price);
            PlayerPrefs.SetInt("LockButton" + _currentLockButton.PlanetNumber + "Off", One);
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
