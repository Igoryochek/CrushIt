using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyGuardMover : Mover
{

    private Health _target;


    public override void Move()
    {
        if (_health.IsDead == false)
        {
            if (_shooter.IsShooting)
            {
                _target = _shooter.Target;
                Vector3 newPosition = new Vector3(transform.position.x + (_target.transform.position.x - transform.position.x), transform.position.y,
                    transform.position.z + (_target.transform.position.z - transform.position.z));
                if (Vector3.Distance(transform.position, newPosition) > _stopMovingDistance)
                {
                    _animatorController.Run();
                    transform.position = Vector3.MoveTowards(transform.position, newPosition, _movingSpeed * Time.deltaTime);
                    Rotate(newPosition);
                }
                else
                {
                    Rotate(newPosition);
                    _animatorController.StopRunAndShoot();
                }
            }
            else
            {
                _animatorController.StopRun();
            }
        }


    }
}
