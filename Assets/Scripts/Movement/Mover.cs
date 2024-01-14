using GeneralHealth;
using Level;
using Shooting;
using UnityEngine;

namespace Movement
{
    [RequireComponent(typeof(Rigidbody))]
    [RequireComponent(typeof(Shooter))]
    [RequireComponent(typeof(Health))]
    [RequireComponent(typeof(AnimatorController))]

    public abstract class Mover : MonoBehaviour
    {
        [SerializeField] protected float RotationSpeed;
        [SerializeField] protected float Speed;
        [SerializeField] protected float StopMovingDistance;

        protected float StartSpeed;
        protected Rigidbody Rigidbody;
        protected Vector3 CurrentDirection;
        protected Shooter Shooter;
        protected Health Health;
        protected AnimatorController AnimatorController;

        public float MovingSpeed => Speed;

        private void Awake()
        {
            Rigidbody = GetComponent<Rigidbody>();
            Shooter = GetComponent<Shooter>();
            Health = GetComponent<Health>();
            AnimatorController = GetComponent<AnimatorController>();
            StartSpeed = MovingSpeed;
        }

        private void FixedUpdate()
        {
            if (Health.IsDead == false)
            {
                Move();
            }
        }

        public abstract void Move();

        public void Rotate(Vector3 destination)
        {
            Vector3 direction = new Vector3(destination.x, transform.position.y, destination.z) - transform.position;
            Quaternion newDirection = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Lerp(transform.rotation, newDirection, RotationSpeed * Time.deltaTime);
        }
    }
}
