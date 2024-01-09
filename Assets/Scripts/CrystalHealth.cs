using System.Collections;
using UnityEngine;

public class CrystalHealth : Health
{
    [SerializeField] private CrystalMine[] _crystalForMinePrefabs;
    [SerializeField] private int _crystalForPickCount;
    [SerializeField] private float _delay;

    public override void Die()
    {
        GiveBonus();
        _audioSource.Play();
    }

    private void GiveBonus()
    {
        int randomCount = Random.Range(3, _crystalForPickCount);

        for (int i = 0; i < randomCount; i++)
        {
            int randomIndex = Random.Range(0, _crystalForMinePrefabs.Length);
            Instantiate(_crystalForMinePrefabs[randomIndex], transform.position, Quaternion.identity);
        }

        StartCoroutine(Dying());
    }

    private IEnumerator Dying()
    {
        yield return new WaitForSeconds(_delay);
        gameObject.SetActive(false);
    }
}
