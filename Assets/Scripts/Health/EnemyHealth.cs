using Level;
using Movement;
using System.Collections;
using UnityEngine;

namespace GeneralHealth
{
    public class EnemyHealth : Health
    {
        private const int RandomChanceMiddleValue = 3;

        [SerializeField] private ParticleSystem _particlePrefab;
        [SerializeField] private Pooler _helpersPooler;
        [SerializeField] private Pooler _aidKitPooler;
        [SerializeField] private float _delay = 3f;
        [SerializeField] private int _randomChanceMaximumValue;
        [SerializeField] private int _randomChanceMinimumValue;

        public override void Die()
        {
            AnimatorController.Die();
            TryGiveBonus();
        }

        private void TryGiveBonus()
        {
            StartCoroutine(TryingGiveBonus());
        }

        private IEnumerator TryingGiveBonus()
        {
            yield return new WaitForSeconds(_delay);
            Instantiate(_particlePrefab, transform.position, Quaternion.identity);
            int randomChance = Random.Range(_randomChanceMinimumValue, _randomChanceMaximumValue);

            if (randomChance > RandomChanceMiddleValue)
            {
                if (_aidKitPooler.TryGetObject(out GameObject aidKit))
                {
                    aidKit.transform.position = new Vector3(transform.position.x, transform.position.y + transform.position.y,
                        transform.position.z);
                    aidKit.transform.rotation = aidKit.transform.rotation;
                    aidKit.SetActive(true);
                    gameObject.SetActive(false);
                }

                yield break;
            }

            if (_helpersPooler.TryGetObject(out GameObject helper))
            {
                helper.transform.position = transform.position;
                helper.transform.rotation = transform.rotation;
                helper.SetActive(true);
                helper.GetComponent<HelperHealth>().Revive();
                helper.GetComponent<HelperMover>().StandUp();
            }

            gameObject.SetActive(false);
        }
    }
}
