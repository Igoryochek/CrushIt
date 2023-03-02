using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMover : Mover
{

    private bool _needMove = false;
    public override void Move()
    {

        if (_needMove)
        {
            _rigidbody.MovePosition(_currentDirection);
            _needMove = false;
            if (_shooter.IsShooting)
            {

                Rotate(_shooter.Target.position);
            }
            else
            {
                Rotate(_currentDirection);
            }
        }

    }

    public void SetNeedMove(Vector3 direction)
    {
        _currentDirection = direction;
        _needMove = true;
    }
}
