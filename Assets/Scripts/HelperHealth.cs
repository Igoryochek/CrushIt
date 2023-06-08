using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelperHealth : Health
{
    public override void Die()
    {
        _animatorController.Die();
        StartCoroutine(Dying());
    }
    private IEnumerator Dying()
    {

        yield return new WaitForSeconds(3);
        gameObject.SetActive(false);

    }
}
