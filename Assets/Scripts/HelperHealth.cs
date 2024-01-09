using System.Collections;
using UnityEngine;

public class HelperHealth : Health
{
    [SerializeField] private float _delay = 3f;
    public override void Die()
    {
        _animatorController.Die();
        StartCoroutine(Dying());
    }

    private IEnumerator Dying()
    {
        yield return new WaitForSeconds(_delay);
        gameObject.SetActive(false);
    }
}
