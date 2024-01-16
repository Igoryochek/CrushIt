using System.Collections;
using UnityEngine;

namespace UI
{
    public class UpgradesPanel : MonoBehaviour
    {
        [SerializeField] private UpgradeButton[] _upgradeButtons;
        [SerializeField] private float _delay = 0.2f;

        private void OnEnable()
        {
            StartCoroutine(Renewing());
        }

        private IEnumerator Renewing()
        {
            WaitForSeconds waitForSeconds = new WaitForSeconds(_delay);
            yield return waitForSeconds;

            foreach (var button in _upgradeButtons)
            {
                button.RenewData();
            }
        }
    }
}