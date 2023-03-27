using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMover : Mover
{

    private bool _needMove = false;
    private bool _isPushingButton = false;
    private bool _isFirstTimePushingButton = true;
    private  float _pushingDelay=1.5f;
    private Coroutine _pushingButton;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out SecretSwitch secretSwitch))
        {
            if (_pushingButton==null&&_isFirstTimePushingButton)
            {
                _animatorController.PushButton();
                _pushingButton =StartCoroutine(PushingButton());
                Rotate(secretSwitch.transform.position);
                _isFirstTimePushingButton = false;
            }
        }
    }

    private IEnumerator PushingButton()
    {
        _rigidbody.velocity = Vector3.zero;
        _movingSpeed = 0;
        _isPushingButton = true;
        yield return new WaitForSeconds(_pushingDelay);
        _isPushingButton = false;
        _movingSpeed = _startSpeed;
    }
    public override void Move()
    {

        if (_needMove&& _isPushingButton == false)
        {

                _animatorController.Run();
                if (_shooter.IsShooting)
                {

                    Rotate(_shooter.Target.transform.position);
                }
                else
                {
                    Vector3 newDirection = new Vector3(transform.position.x + _currentDirection.x,
                        transform.position.y, transform.position.z + _currentDirection.z);
                    Rotate(newDirection);
                }
                _rigidbody.velocity = new Vector3(_currentDirection.x * _movingSpeed, _rigidbody.velocity.y, _currentDirection.z * _movingSpeed);
            
        }
        else
        {
            if (_shooter.IsShooting)
            {
                _animatorController.StopRunAndShoot();
            }
            else
            {
                _animatorController.StopRun();
            }
        }


    }

    public void SetNeedMove(Vector3 direction)
    {
        _currentDirection =direction ;
        _needMove = true;
    } 
    public void SetNoNeedMove()
    {
        _needMove = false;
        _rigidbody.velocity = Vector3.zero;
    }
}
