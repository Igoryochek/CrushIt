using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : Health
{

    [SerializeField] private Helper _helperPrefab;
    [SerializeField] private AidKit _aidKitPrefab;
    [SerializeField] private ParticleSystem _particlePrefab;


    public override void Die()
    {
        _animatorController.Die();
        TryGiveBonus();
    }

    private void TryGiveBonus()
    {
        StartCoroutine(TryingGiveBonus());
    }

    private IEnumerator TryingGiveBonus()
    {        
        yield return new WaitForSeconds(3);
        Instantiate(_particlePrefab, transform.position,Quaternion.identity);
        int randomChance = Random.Range(0, 10);
        if (randomChance < 3)
        {


            Instantiate(_helperPrefab, transform.position, transform.rotation);
        }
        else if (randomChance>3)
        {
            Vector3 aidPrefabNewPosition = new Vector3(transform.position.x,_aidKitPrefab.transform.position.y,transform.position.z);
            Instantiate(_aidKitPrefab,aidPrefabNewPosition, _aidKitPrefab.transform.rotation);
        }
        gameObject.SetActive(false);

    }
}
