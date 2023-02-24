using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Bullet : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private int _damage;


    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out IShootable shootable))
        {
            shootable.TakeDamage(_damage);
        }
    }

    public void MoveTo(Vector3 target)
    {
        StartCoroutine(Moving(target));
    }

    private IEnumerator Moving(Vector3 target)
    {
        while (transform.position!=target)
        {
            transform.position = Vector3.MoveTowards(transform.position,target,_speed*Time.deltaTime);
            yield return null;
        }
        Destroy(gameObject);
    }


}
