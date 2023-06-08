using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hints : MonoBehaviour
{
    [SerializeField] private GameObject _crystalHint;
    [SerializeField] private GameObject _enemyHint;
    [SerializeField] private GameObject _shipHint;
    [SerializeField] private GameObject _joystickHint;
    [SerializeField] private GameObject _buttonsHint;

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
        yield return new WaitForSeconds(4);
        if (_isMobile)
        {
            _joystickHint.SetActive(true);
        }
        else
        {
            _buttonsHint.SetActive(true);

        }
        yield return new WaitForSeconds(2);
        _crystalHint.SetActive(true);
        yield return new WaitForSeconds(2);
        _shipHint.SetActive(true);
        yield return new WaitForSeconds(2);
        _enemyHint.SetActive(true);       
    }
}
