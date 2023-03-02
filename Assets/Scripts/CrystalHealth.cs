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
    }

    private void GiveBonus()
    {
        for (int i = 0; i < _crystalForPickCount; i++)
        {
            int randomIndex = Random.Range(0,_crystalForMinePrefabs.Length-1);
            Instantiate(_crystalForMinePrefabs[randomIndex],transform.position,Quaternion.identity);
        }
        gameObject.SetActive(false);
    }
}
