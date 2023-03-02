using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : Health
{

    [SerializeField] private Helper _helperPrefab;


    public override void Die()
    {
        _animatorController.Die();
        int randomChance = Random.Range(0,10);
        if (randomChance<3)
        {
            GiveBonus();
        }
    }

    private void GiveBonus()
    {
        StartCoroutine(GivingBonus());
    }

    private IEnumerator GivingBonus()
    {        
        yield return new WaitForSeconds(3);
        Instantiate(_helperPrefab, transform.position, Quaternion.identity);
        gameObject.SetActive(false);
    }
}
