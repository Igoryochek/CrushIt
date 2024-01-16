using System.Collections;
using UnityEngine;

namespace Shooting
{
    public class ShootPartical : MonoBehaviour
    {
        [SerializeField] private float _delay = 1f;

        private void Start()
        {
            StartCoroutine(Living());
        }

        private IEnumerator Living()
        {
            WaitForSeconds waitForSeconds = new WaitForSeconds(_delay);
            yield return waitForSeconds;
            Destroy(gameObject);
        }
    }
}