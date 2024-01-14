using System.Collections;
using UnityEngine;

namespace Level
{
    public class Hints : MonoBehaviour
    {
        [SerializeField] private GameObject _crystalHint;
        [SerializeField] private GameObject _enemyHint;
        [SerializeField] private GameObject _shipHint;
        [SerializeField] private GameObject _joystickHint;
        [SerializeField] private GameObject _buttonsHint;
        [SerializeField] private float _showingDelay;

        private void Start()
        {
            if (Application.isMobilePlatform)
            {
                _joystickHint.SetActive(true);
            }
            else
            {
                _buttonsHint.SetActive(true);
            }

            StartCoroutine(ShowingHints());
        }

        private IEnumerator ShowingHints()
        {
            yield return new WaitForSeconds(_showingDelay);
            _crystalHint.SetActive(true);
            yield return new WaitForSeconds(_showingDelay);
            _shipHint.SetActive(true);
            yield return new WaitForSeconds(_showingDelay);
            _enemyHint.SetActive(true);
        }
    }
}

