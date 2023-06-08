using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrystalHealth : Health
{
    [SerializeField] private CrystalMine[] _crystalForMinePrefabs;
    [SerializeField] private int _crystalForPickCount;

    public override void Die()
    {
        GiveBonus();
        _audioSource.Play();
    }

    private void GiveBonus()
    {
        int randomCount = Random.Range(3,_crystalForPickCount);
        for (int i = 0; i < randomCount; i++)
        {
            int randomIndex = Random.Range(0,_crystalForMinePrefabs.Length-1);
            Instantiate(_crystalForMinePrefabs[randomIndex],transform.position,Quaternion.identity);
        }
        StartCoroutine(Dying());
    }

    private IEnumerator Dying()
    {
        yield return new WaitForSeconds(0.2f);
        gameObject.SetActive(false);
    }
}
