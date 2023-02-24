using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Shooter))]
public class PLayerMover : MonoBehaviour
{
    [SerializeField] private Transform _point;
    [SerializeField] private float _movingSpeed;
    [SerializeField] private float _rotationSpeed;

    private Rigidbody _rigidbody;
    private Vector3 _currentDirection;
    private Vector3 _currentTarget;
    private Shooter _shooter;
    private List<HelperMover> _helpers=new();

    public float MovingSpeed => _movingSpeed;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _shooter = GetComponent<Shooter>();
    }

    public void Move(Vector3 direction)
    {
        _currentDirection = direction;
        _rigidbody.MovePosition(_currentDirection);
        if (_shooter.IsShooting)
        {

            Rotate(_shooter.Target.position);
        }
        else
        {
            Rotate(direction);
        }
    }

    private void Rotate(Vector3 destination)
    {
        Vector3 direction = destination - transform.position;
        Quaternion newDirection = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Lerp(transform.rotation,newDirection,_rotationSpeed*Time.deltaTime);
    }



    public void AddHelper(HelperMover helper)
    {
        _helpers.Add(helper);
    }
    
    public void RemoveHelper(HelperMover helper)
    {
        _helpers.Remove(helper);
    }
}
