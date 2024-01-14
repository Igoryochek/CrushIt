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
            yield return new WaitForSeconds(_delay);
            _gameOverPanel.SetActive(true);
        }
    }
}
