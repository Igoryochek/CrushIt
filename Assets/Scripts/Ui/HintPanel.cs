using System.Collections;
using UnityEngine;

namespace UI
{
    public class HintPanel : MonoBehaviour
    {
        private const float FullSoundValue = 1f;
        private const float ZeroSoundValue = 0f;

        [SerializeField] private float _showingTime;

        private Coroutine _showing;

        private void OnEnable()
        {
            Show();
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
            WaitForSeconds waitForSeconds = new WaitForSeconds(_showingTime);
            Time.timeScale = ZeroSoundValue;
            yield return waitForSeconds;
            Time.timeScale = FullSoundValue;
            gameObject.SetActive(false);
        }
    }
}