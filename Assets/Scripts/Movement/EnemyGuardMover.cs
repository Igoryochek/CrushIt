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
                MoveToTarget(_target);
            }
        }
    }
}