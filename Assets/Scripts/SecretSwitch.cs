using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SecretSwitch : MonoBehaviour
{
    public event UnityAction TurnedOn;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out PlayerMover player))
        {
            TurnedOn?.Invoke();
        }
    }
}
