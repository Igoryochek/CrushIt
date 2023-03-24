using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Secret : MonoBehaviour
{
    [SerializeField] private SecretSwitch _secretSwitch;
    [SerializeField] private HintPanel _hintPanel;

    private void OnEnable()
    {
        _secretSwitch.TurnedOn += OnTurnedOn;
    }

    private void OnDisable()
    {
        _secretSwitch.TurnedOn -= OnTurnedOn;

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (gameObject.TryGetComponent(out FirstSecret firstSecret) && collision.gameObject.TryGetComponent(out Player player))
        {
            _hintPanel.gameObject.SetActive(true);
        }
    }

    private void OnTurnedOn()
    {
        gameObject.SetActive(false);
    }
}
