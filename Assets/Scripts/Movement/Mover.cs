using GeneralHealth;
using Level;
using Shooting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

namespace Movement
{
    [RequireComponent(typeof(Rigidbody))]
    [RequireComponent(typeof(Shooter))]
    [RequireComponent(typeof(Health))]
    [RequireComponent(typeof(AnimatorStateChanger))]

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
        protected AnimatorStateChanger AnimatorController;

        public float MovingSpeed => Speed;

        private void Awake()
        {
            Rigidbody = GetComponent<Rigidbody>();
            Shooter = GetComponent<Shooter>();
            Health = GetComponent<Health>();
            AnimatorController = GetComponent<AnimatorStateChanger>();
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

        public void MoveToTarget(Health target)
        {
            target = Shooter.Target;
            Vector3 newPosition = new Vector3(
                transform.position.x + (target.transform.position.x - transform.position.x),
            transform.position.y,
                transform.position.z + (target.transform.position.z - transform.position.z));
            TurnToTarget(newPosition);
        }

        public void Rotate(Vector3 destination)
        {
            Vector3 direction = new Vector3(destination.x, transform.position.y, destination.z) - transform.position;
            Quaternion newDirection = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Lerp(transform.rotation, newDirection, RotationSpeed * Time.deltaTime);
        }

        private void TurnToTarget(Vector3 newPosition)
        {
            if (Vector3.Distance(transform.position, newPosition) <= StopMovingDistance)
            {
                AnimatorController.Shoot();
                return;
            }

            AnimatorController.Run();
            transform.position = Vector3.MoveTowards(transform.position, newPosition, MovingSpeed * Time.deltaTime);
            Rotate(newPosition);
        }
    }
}