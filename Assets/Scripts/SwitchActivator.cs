using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchActivator : MonoBehaviour
{
    [SerializeField] private SecretSwitch _secretSwitch;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Player player))
        {
            SetSwitchActive();
        }
    }

    private void SetSwitchActive()
    {
        _secretSwitch.gameObject.SetActive(true);
        gameObject.SetActive(false);
    }
}
