using GeneralHealth;
using UnityEngine;

namespace Movement
{
    public class EnemyGuardMover : Mover
    {
        private Health _target;

        public override void Move()
        {
            if (Health.IsDead)
            {
                AnimatorController.StopRun();
                return;
            }

            if (Shooter.IsShooting)
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
}