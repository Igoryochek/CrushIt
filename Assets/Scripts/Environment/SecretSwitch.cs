using System;
using Movement;
using UnityEngine;

namespace Environment
{
    public class SecretSwitch : MonoBehaviour
    {
        public event Action TurnedOn;

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out PlayerMover player))
            {
                TurnedOn?.Invoke();
            }
        }
    }
}