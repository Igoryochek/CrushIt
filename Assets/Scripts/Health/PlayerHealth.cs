using System.Collections;
using UnityEngine;

namespace GeneralHealth
{
    public class PlayerHealth : Health
    {
        [SerializeField] private GameObject _gameOverPanel;
        [SerializeField] private float _delay = 2f;
        [SerializeField] private int _additiveHealth = 100;

        public override void Die()
        {
            AnimatorController.Die();
            StartCoroutine(Dying());
        }

        public void RiseUp()
        {
            AnimatorController.RisingUp();
            IsDeadCondition = false;
            Heal(_additiveHealth);
        }

        private IEnumerator Dying()
        {
            WaitForSeconds waitForSeconds = new WaitForSeconds(_delay);
            yield return waitForSeconds;
            _gameOverPanel.SetActive(true);
        }
    }
}