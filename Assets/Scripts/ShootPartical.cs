using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootPartical : MonoBehaviour
{
    private void Start()
    {
        StartCoroutine(Living());
    }

    private IEnumerator Living()
    {
        yield return new WaitForSeconds(1);
        Destroy(gameObject);
    }
}
