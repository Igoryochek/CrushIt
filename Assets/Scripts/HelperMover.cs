using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelperMover : MonoBehaviour,IShootable
{
    [SerializeField] private float _movingSpeed;
    [SerializeField] private float _rotatingSpeed;
    [SerializeField] private Transform _point;

    private Rigidbody _rigidbody;
    private Shooter _shooter;
    private Coroutine _moving;

    public Transform Point => _point;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _shooter = GetComponent<Shooter>();
    }

    public void Move(Vector3 point)
    {
        if (_moving==null)
        {
            _moving=StartCoroutine(Moving(point));

        }
    }

    public void StopMove()
    {
        if (_moving!=null)
        {
            StopCoroutine(_moving);
            _moving = null;
        }
    }

    private IEnumerator Moving(Vector3 point)
    {
        Vector3 newPosition = new Vector3(point.x,transform.position.y,point.z);
        while (transform.position!=newPosition)
        {
            transform.position = Vector3.MoveTowards(transform.position,newPosition,_movingSpeed*Time.deltaTime);
            if (_shooter.IsShooting == false)
            {
                RotateTo(newPosition);
            }
            else
            {

                    RotateTo(_shooter.Target.position);
                
            }
            yield return null;
        }
        _moving = null;
    }

    private void RotateTo(Vector3 target)
    {
        Vector3 direction = target - transform.position;
        Quaternion newRotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Lerp(transform.rotation, newRotation, _rotatingSpeed * Time.deltaTime);
    }

    public void TakeDamage(int count)
    {
        throw new System.NotImplementedException();
    }
}
