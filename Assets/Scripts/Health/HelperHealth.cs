using System.Collections;
using UnityEngine;

namespace GeneralHealth
{
    public class HelperHealth : Health
    {
        [SerializeField] private float _delay = 3f;

        public override void Die()
        {
            AnimatorController.Die();
            StartCoroutine(Dying());
        }

        private IEnumerator Dying()
        {
            WaitForSeconds waitForSeconds = new WaitForSeconds(_delay);
            yield return waitForSeconds;
            gameObject.SetActive(false);
        }
    }
}