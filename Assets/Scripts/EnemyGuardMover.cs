using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyGuardMover : Mover
{

    private Transform _target;


    public override void Move()
    {

        if (_shooter.IsShooting)
        {
            if (_target==null)
            {
                _target = _shooter.Target;
            }
            Rotate(_target.position);            
        }
        if (_target != null &&Vector3.Distance(_target.position, transform.position) > 8)
        {
            Vector3 newPosition = new Vector3(transform.position.x + (_target.position.x - transform.position.x) * _movingSpeed * Time.deltaTime,
            transform.position.y, transform.position.z + (_target.position.z - transform.position.z) * _movingSpeed * Time.deltaTime);
            _rigidbody.MovePosition(newPosition);
            Debug.Log(transform.position+_target.position * _movingSpeed * Time.deltaTime);
            transform.LookAt(newPosition);
            _animatorController.Walk();
        }
        else
        {
            _animatorController.StopWalk();
        }
    }
}
