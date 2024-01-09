using System.Collections;
using UnityEngine;

public class ShootPartical : MonoBehaviour
{
    [SerializeField] private float _delay = 1f;
    private void Start()
    {
        StartCoroutine(Living());
    }

    private IEnumerator Living()
    {
        yield return new WaitForSeconds(_delay);
        Destroy(gameObject);
    }
}
