using System.Collections;
using UnityEngine;

namespace UI
{
    public class HintPanel : MonoBehaviour
    {
        private const float FullSoundValue = 1f;
        private const float ZeroSoundValue = 0f;
        private const int LeftMouseButtonNumber = 0;

        [SerializeField] private float _showingTime;

        private Coroutine _showing;
        private bool _isMobile = false;

        private void OnEnable()
        {
            Show();
        }

        private void Start()
        {
            if (Application.isMobilePlatform)
            {
                _isMobile = true;
            }
        }

        private void OnMouseDown()
        {
            StopShow();
        }

        private void Show()
        {
            if (_showing == null)
            {
                _showing = StartCoroutine(Showing());
            }
        }

        private void StopShow()
        {
            StopCoroutine(_showing);
            Time.timeScale = FullSoundValue;
            gameObject.SetActive(false);
        }

        private IEnumerator Showing()
        {
            Time.timeScale = ZeroSoundValue;
            yield return new WaitForSecondsRealtime(_showingTime);
            Time.timeScale = FullSoundValue;
            gameObject.SetActive(false);
        }
    }
}