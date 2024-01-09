using System.Collections;
using UnityEngine;

public class EnemyHealth : Health
{
    [SerializeField] private ParticleSystem _particlePrefab;
    [SerializeField] private Pooler _helpersPooler;
    [SerializeField] private Pooler _aidKitPooler;
    [SerializeField] private float _delay = 3f;
    [SerializeField] private int _randomChanceMaximumValue;

    private const int RandomChanceMiddleValue = 3;

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
        yield return new WaitForSeconds(_delay);
        Instantiate(_particlePrefab, transform.position, Quaternion.identity);
        int randomChance = Random.Range(0, _randomChanceMaximumValue);

        if (randomChance < RandomChanceMiddleValue)
        {
            if (_helpersPooler.TryGetObject(out GameObject helper))
            {
                helper.transform.position = transform.position;
                helper.transform.rotation = transform.rotation;
                helper.SetActive(true);
                helper.GetComponent<HelperHealth>().SetNoDie();
                helper.GetComponent<HelperMover>().Starting();
            }
        }
        else if (randomChance > RandomChanceMiddleValue)
        {
            if (_aidKitPooler.TryGetObject(out GameObject aidKit))
            {
                aidKit.transform.position = new Vector3(transform.position.x, transform.position.y + 1, transform.position.z);
                aidKit.transform.rotation = aidKit.transform.rotation;
                aidKit.SetActive(true);
            }
        }

        gameObject.SetActive(false);
    }
}
