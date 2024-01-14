using Counter;
using TMPro;
using UnityEngine;

namespace UI
{
    public class LockPanel : MonoBehaviour
    {
        private const int One = 1;

        [SerializeField] private MenuCrystalCounter _crystalCounter;
        [SerializeField] private TextMeshProUGUI _text;

        private LockButton _currentLockButton;

        public void SetCurrentLockButton(LockButton button)
        {
            _currentLockButton = button;
        }

        public void RemoveLockButton()
        {
            if (_crystalCounter.CrystalsCount < _currentLockButton.Price)
            {
                _text.gameObject.SetActive(true);
                return;
            }

            _crystalCounter.RemoveCrystals(_currentLockButton.Price);
            PlayerPrefs.SetInt(PlayerPrefsKeys.LockButtonOff + _currentLockButton.PlanetNumber.ToString(), One);
            _currentLockButton.gameObject.SetActive(false);
            gameObject.SetActive(false);
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
}
