using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Shooter))]
[RequireComponent(typeof(Health))]
[RequireComponent(typeof(AnimatorController))]

public abstract class Mover : MonoBehaviour
{
    [SerializeField] protected float _rotationSpeed;
    [SerializeField] protected float _movingSpeed;
    [SerializeField] protected float _stopMovingDistance;

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

    private void FixedUpdate()
    {
        if (_health.IsDead == false)
        {
            Move();
        }
    }

    public abstract void Move();

    public void Rotate(Vector3 destination)
    {
        Vector3 direction = new Vector3(destination.x, transform.position.y, destination.z) - transform.position;
        Quaternion newDirection = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Lerp(transform.rotation, newDirection, _rotationSpeed * Time.deltaTime);
    }
}
