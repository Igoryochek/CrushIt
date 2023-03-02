using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Shooter))]
[RequireComponent(typeof(AnimatorController))]

public abstract class Mover : MonoBehaviour
{
    [SerializeField] protected float _movingSpeed;
    [SerializeField] private float _rotationSpeed;

    protected Rigidbody _rigidbody;
    protected Vector3 _currentDirection;
    protected Shooter _shooter;
    protected AnimatorController _animatorController;

    public float MovingSpeed => _movingSpeed;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _shooter = GetComponent<Shooter>();
        _animatorController = GetComponent<AnimatorController>();
    }
    private void LateUpdate()
    {
        Move();
    }
    public abstract void Move();

    public void Rotate(Vector3 destination)
    {
        Vector3 direction = destination - transform.position;
        Quaternion newDirection = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Lerp(transform.rotation,newDirection,_rotationSpeed*Time.deltaTime);
    }
}
