using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Shooter))]
[RequireComponent(typeof(Health))]
[RequireComponent(typeof(AnimatorController))]

public abstract class Mover : MonoBehaviour
{
    [SerializeField] private float _rotationSpeed;
    [SerializeField] protected float _movingSpeed;
    [SerializeField] protected float _stopMovingDistance;

    private const float RotationOffset = 5;

    protected float _startSpeed;
    protected Rigidbody _rigidbody;
    protected Vector3 _currentDirection;
    protected Shooter _shooter;
    protected Health _health;
    protected AnimatorController _animatorController;

    public float MovingSpeed => _movingSpeed;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _shooter = GetComponent<Shooter>();
        _health = GetComponent<Health>();
        _animatorController = GetComponent<AnimatorController>();
        _startSpeed = _movingSpeed;
    }
    private void Update()
    {
        if (_health.IsDead==false)
        {
            Move();
        }
    }
    public abstract void Move();

    public void Rotate(Vector3 destination)
    {

        Vector3 direction =new Vector3( destination.x,transform.position.y,destination.z) - transform.position;
        Quaternion newDirection = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Lerp(transform.rotation,newDirection,_rotationSpeed*Time.deltaTime);
        //transform.eulerAngles = new Vector3(transform.eulerAngles.x,transform.eulerAngles.y+RotationOffset,transform.eulerAngles.z);

    }
}
