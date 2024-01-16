using System.Collections;
using GeneralHealth;
using PlayerMain;
using UnityEngine;

namespace Shooting
{
    [RequireComponent(typeof(Health))]

    public class Shooter : MonoBehaviour
    {
        [SerializeField] private Weapon _weapon;
        [SerializeField] private float _timeBetweenShoot;
        [SerializeField] private float _timeBetweenTryingShoot;
        [SerializeField] private float _bulletSpeed;
        [SerializeField] private int _damage;
        [SerializeField] private float _shootingDistance;
        [SerializeField] private float _stopShootingDistance;
        [SerializeField] private LayerMask _layerMask;

        private Coroutine _shooting;
        private bool _isShooting = false;
        private Health _currentTarget;
        private Health _selfHealth;

        public Health Target => _currentTarget;

        public int Damage => _damage;

        public bool IsShooting => _isShooting;

        private void Start()
        {
            if ((gameObject.TryGetComponent(out Player player) ||
                gameObject.TryGetComponent(out Helper helper))
                && PlayerPrefs.HasKey(PlayerPrefsKeys.PlayerBulletSpeed))
            {
                _bulletSpeed = PlayerPrefs.GetInt(PlayerPrefsKeys.PlayerBulletSpeed);
            }

            _selfHealth = GetComponent<Health>();
            StartCoroutine(TryingShoot());
        }

        public float BulletSpeed()
        {
            float speed;

            if ((gameObject.TryGetComponent(out Player player) ||
                gameObject.TryGetComponent(out Helper helper))
                && PlayerPrefs.HasKey(PlayerPrefsKeys.PlayerBulletSpeed))
            {
                speed = PlayerPrefs.GetInt(PlayerPrefsKeys.PlayerBulletSpeed);
            }
            else
            {
                speed = _bulletSpeed;
            }

            return speed;
        }

        private IEnumerator TryingShoot()
        {
            WaitForSeconds waitForSeconds = new WaitForSeconds(_timeBetweenTryingShoot);

            while (gameObject.activeSelf)
            {
                if (TryShoot(out Health target))
                {
                    Shoot(target);
                }

                yield return waitForSeconds;
            }
        }

        private bool TryShoot(out Health target)
        {
            Health currentTarget = null;
            target = currentTarget;
            Collider[] colliders = Physics.OverlapSphere(transform.position, _shootingDistance, _layerMask);

            foreach (var collider in colliders)
            {
                if (collider.gameObject.TryGetComponent(out Health health) && health.IsDead == false && health.gameObject != gameObject)
                {
                    target = health;
                }
            }

            return target != null;
        }

        private void Shoot(Health target)
        {
            _currentTarget = target;
            _isShooting = true;
            _shooting = StartCoroutine(Shooting(_currentTarget));
        }

        private IEnumerator Shooting(Health target)
        {
            WaitForSeconds waitForSeconds = new WaitForSeconds(_timeBetweenShoot);

            while (_selfHealth.IsDead == false &&
                _currentTarget != null &&
                target.IsDead == false &&
                Vector3.Distance(_currentTarget.transform.position, transform.position) < _stopShootingDistance)
            {
                _weapon.Shoot(_currentTarget);
                yield return null;
                yield return waitForSeconds;
            }

            _isShooting = false;
            _shooting = null;
            _currentTarget = null;
        }
    }
}