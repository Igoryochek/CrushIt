using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrolerMover : Mover
{
    [SerializeField] private Transform _pointOne;
    [SerializeField] private Transform _pointTwo;
    [SerializeField] private float _patrolSpeed;

    private bool _pointOneMoving = false;
    private Health _target;

    private void Start()
    {
        transform.position =new Vector3( _pointOne.position.x,transform.position.y,_pointOne.position.z);
        _animatorController.Run();
    }
    public override void Move()
    {
        if (_health.IsDead == false)
        {
            if (_shooter.IsShooting)
            {
                _target = _shooter.Target;
                Vector3 newPosition = new Vector3(transform.position.x + (_target.transform.position.x - transform.position.x), transform.position.y,
                    transform.position.z + (_target.transform.position.z - transform.position.z));
                if (Vector3.Distance(transform.position,newPosition)>_stopMovingDistance)
                {
                    _animatorController.Run();
                    transform.position = Vector3.MoveTowards(transform.position, newPosition, _movingSpeed * Time.deltaTime);
                    Rotate(newPosition);
                }
                else
                {
                    _animatorController.StopRunAndShoot();
                }

            }
            else
            {
                _animatorController.Run();
                if (_pointOneMoving == false)
                {
                    transform.position = Vector3.MoveTowards(transform.position,
                        new Vector3(_pointTwo.position.x, transform.position.y, _pointTwo.position.z), _patrolSpeed * Time.deltaTime);
                    
                    if (transform.position == new Vector3(_pointTwo.position.x, transform.position.y, _pointTwo.position.z))
                    {
                        _pointOneMoving = true;

                    }
                    else
                    {
                        Rotate(new Vector3(_pointTwo.position.x, transform.position.y, _pointTwo.position.z));
                    }
                }
                else
                {
                    transform.position = Vector3.MoveTowards(transform.position,
                        new Vector3(_pointOne.position.x, transform.position.y, _pointOne.position.z), _patrolSpeed * Time.deltaTime);
                    if (transform.position == new Vector3(_pointOne.position.x, transform.position.y, _pointOne.position.z))
                    {
                        _pointOneMoving = false;
                    }
                    else
                    {
                        Rotate(new Vector3(_pointOne.position.x, transform.position.y, _pointOne.position.z));

                    }

                }

            }

        }    
    }


}
