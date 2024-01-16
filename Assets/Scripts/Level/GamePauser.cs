using UnityEngine;

namespace Level
{
    public class GamePauser : MonoBehaviour
    {
        private const float FullTimeValue = 1f;
        private const float ZeroTimeValue = 0f;

        [SerializeField] private SoundSwitcher _audioManager;
        [SerializeField] private Ads _ads;

        private void OnEnable()
        {
            _ads.StartAdsShowing += OnStartAdsShowing;
        }

        private void OnDisable()
        {
            _ads.StartAdsShowing -= OnStartAdsShowing;
        }

        public void StopGame()
        {
            Time.timeScale = ZeroTimeValue;
            _audioManager.TurnOffSound();
        }

        public void PlayGame()
        {
            Time.timeScale = FullTimeValue;
            _audioManager.TurnOnSound();
        }

        private void OnStartAdsShowing()
        {
            StopGame();
        }
    }
}