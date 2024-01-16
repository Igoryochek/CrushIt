using GeneralHealth;
using UnityEngine;

namespace Movement
{
    public class EnemyPatrolerMover : Mover
    {
        [SerializeField] private Transform _pointOne;
        [SerializeField] private Transform _pointTwo;
        [SerializeField] private float _patrolSpeed;

        private bool _pointOneMoving = false;
        private Health _target;

        private void Start()
        {
            transform.position = new Vector3(_pointOne.position.x, transform.position.y, _pointOne.position.z);
            AnimatorController.Run();
        }

        public override void Move()
        {
            if (Health.IsDead == false && Shooter.IsShooting == false)
            {
                MoveToPoint();
            }

            MoveToTarget();
        }

        private void MoveToPoint()
        {
            AnimatorController.Run();

            if (_pointOneMoving)
            {
                Vector3 pointOnePosition = new Vector3(_pointOne.position.x, transform.position.y, _pointOne.position.z);
                transform.position = Vector3.MoveTowards(transform.position, pointOnePosition, _patrolSpeed * Time.deltaTime);

                if (transform.position != new Vector3(_pointOne.position.x, transform.position.y, _pointOne.position.z))
                {
                    Rotate(new Vector3(_pointOne.position.x, transform.position.y, _pointOne.position.z));
                    return;
                }

                _pointOneMoving = false;
                return;
            }

            Vector3 pointTwoPosition = new Vector3(_pointTwo.position.x, transform.position.y, _pointTwo.position.z);
            transform.position = Vector3.MoveTowards(transform.position, pointTwoPosition, _patrolSpeed * Time.deltaTime);

            if (transform.position != new Vector3(_pointTwo.position.x, transform.position.y, _pointTwo.position.z))
            {
                Rotate(new Vector3(_pointTwo.position.x, transform.position.y, _pointTwo.position.z));
                return;
            }

            _pointOneMoving = true;
        }

        private void MoveToTarget()
        {
            _target = Shooter.Target;
            Vector3 newPosition = new Vector3(
                transform.position.x + (_target.transform.position.x - transform.position.x),
                transform.position.y,
                transform.position.z + (_target.transform.position.z - transform.position.z));
            TurnToTarget(newPosition);
        }
    }
}