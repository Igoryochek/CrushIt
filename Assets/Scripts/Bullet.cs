using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Bullet : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private int _damage;


    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Health health))
        {
            health.TakeDamage(_damage);
            gameObject.SetActive(false);
        }
    }

    public void MoveTo(Transform target)
    {
        StartCoroutine(Moving(target));
    }

    private IEnumerator Moving(Transform target)
    {
        Vector3 newPosition = new Vector3(target.position.x,transform.position.y, target.position.z);
        while (transform.position!=newPosition)
        {
            transform.position = Vector3.MoveTowards(transform.position,newPosition,_speed*Time.deltaTime);
            yield return null;
        }
        gameObject.SetActive(false);
    }


}
