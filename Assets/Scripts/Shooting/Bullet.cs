using System.Collections;
using GeneralHealth;
using UnityEngine;

namespace Shooting
{
    public abstract class Bullet : MonoBehaviour
    {
        [SerializeField] private int _damage;
        [SerializeField] private ParticleSystem _shootParticalPrefab;

        private float _speed;

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out Health health))
            {
                health.TakeDamage(_damage);
                Destroy();
            }
        }

        public void MoveTo(Transform target)
        {
            StartCoroutine(Moving(target));
        }

        public void SetSpeed(float speed)
        {
            _speed = speed;
        }

        public void SetDamage(int damage)
        {
            _damage = damage;
        }

        private void Destroy()
        {
            Instantiate(_shootParticalPrefab, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }

        private IEnumerator Moving(Transform target)
        {
            Vector3 newPosition = new Vector3(target.position.x, transform.position.y, target.position.z);

            while (transform.position != newPosition)
            {
                transform.position = Vector3.MoveTowards(transform.position, newPosition, _speed * Time.deltaTime);
                yield return null;
            }

            Destroy();
        }
    }
}