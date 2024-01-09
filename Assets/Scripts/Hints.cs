using System.Collections;
using UnityEngine;

public class Hints : MonoBehaviour
{
    [SerializeField] private GameObject _crystalHint;
    [SerializeField] private GameObject _enemyHint;
    [SerializeField] private GameObject _shipHint;
    [SerializeField] private GameObject _joystickHint;
    [SerializeField] private GameObject _buttonsHint;
    [SerializeField] private float _showingDelay;

    private bool _isMobile = false;

    private void Start()
    {
        StartCoroutine(ShowingHints());

        if (Application.isMobilePlatform)
        {
            _isMobile = true;
        }
    }

    private IEnumerator ShowingHints()
    {
        yield return new WaitForSeconds(_showingDelay);

        if (_isMobile)
        {
            _joystickHint.SetActive(true);
        }
        else
        {
            _buttonsHint.SetActive(true);

        }

        yield return new WaitForSeconds(_showingDelay);
        _crystalHint.SetActive(true);
        yield return new WaitForSeconds(_showingDelay);
        _shipHint.SetActive(true);
        yield return new WaitForSeconds(_showingDelay);
        _enemyHint.SetActive(true);
    }
}
