using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HintPanel : MonoBehaviour
{
    [SerializeField] private float _showingTime;

    private Coroutine _showing;
    private bool _isMobile=false;
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

    private void Update()
    {
        if (Input.anyKeyDown)
        {
            if (!_isMobile&&(!Input.GetKeyDown(KeyCode.RightArrow)|| !Input.GetKeyDown(KeyCode.D) || !Input.GetKeyDown(KeyCode.S)
                || !Input.GetKeyDown(KeyCode.W)))
            {
                StopShow();
            }
        }
        if (Input.GetMouseButtonDown(0))
        {
            StopShow();
        }
    }

    private void Show()
    {
        if (_showing==null)
        {
            _showing=StartCoroutine(Showing());
        }
    }

    private void StopShow()
    {
        StopCoroutine(_showing);
        Time.timeScale = 1;
        gameObject.SetActive(false);
    }

    private IEnumerator Showing()
    {
        Time.timeScale = 0;
        yield return new WaitForSecondsRealtime(_showingTime);
        Time.timeScale = 1;
        gameObject.SetActive(false);

    }
}
