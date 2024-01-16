using UnityEngine;

namespace Environment
{
    public class SwitchActivator : MonoBehaviour
    {
        [SerializeField] private SecretSwitch _secretSwitch;

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out PlayerMain.Player player))
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
}