using System.Collections;
using Crystals;
using UnityEngine;

namespace GeneralHealth
{
    public class CrystalHealth : Health
    {
        private const int CrystalForMinePrefabsZeroLength = 0;

        [SerializeField] private CrystalMine[] _crystalForMinePrefabs;
        [SerializeField] private int _maximumCrystalForPickAmount;
        [SerializeField] private int _minimumCrystalForPickAmount;
        [SerializeField] private float _delay;

        public override void Die()
        {
            GiveBonus();
            AudioSource.Play();
        }

        private void GiveBonus()
        {
            int randomCount = Random.Range(_minimumCrystalForPickAmount, _maximumCrystalForPickAmount);

            for (int i = 0; i < randomCount; i++)
            {
                int randomIndex = Random.Range(CrystalForMinePrefabsZeroLength, _crystalForMinePrefabs.Length);
                Instantiate(_crystalForMinePrefabs[randomIndex], transform.position, Quaternion.identity);
            }

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