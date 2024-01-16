using System.Collections;
using GeneralHealth;
using UnityEngine;

namespace Shooting
{
    public class MashineGun : Weapon
    {
        private const int StartCount = 0;

        [SerializeField] private int _bulletsCountInTime;
        [SerializeField] private float _delay = 0.2f;

        public override void Shoot(Health target)
        {
            StartCoroutine(Shooting(target));
        }

        private IEnumerator Shooting(Health target)
        {
            WaitForSeconds waitForSeconds = new WaitForSeconds(_delay);

            while (_bulletsCountInTime != StartCount)
            {
                Particle.Play();
                target.TakeDamage(Damage);
                _bulletsCountInTime--;
                yield return waitForSeconds;
                yield return null;
            }
        }
    }
}