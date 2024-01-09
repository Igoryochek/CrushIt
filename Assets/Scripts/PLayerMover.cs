using System.Collections;
using UnityEngine;

public class PlayerMover : Mover
{

    private bool _needMove = false;
    private bool _isPushingButton = false;
    private bool _isFirstTimePushingButton = true;
    private Coroutine _pushingButton;

    private const float PushingDelay = 1.5f;

    private void Start()
    {
        if (PlayerPrefs.HasKey("PlayerSpeed"))
        {
            _movingSpeed = PlayerPrefs.GetInt("PlayerSpeed");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out SecretSwitch secretSwitch))
        {
            if (_pushingButton == null && _isFirstTimePushingButton)
            {
                _animatorController.PushButton();
                _pushingButton = StartCoroutine(PushingButton(secretSwitch.transform.position));
                Rotate(secretSwitch.transform.position);
                _isFirstTimePushingButton = false;
            }
        }
    }
    public override void Move()
    {
        if (_needMove && _isPushingButton == false)
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

            _rigidbody.velocity = new Vector3(_currentDirection.x * _movingSpeed, _rigidbody.velocity.y,
                _currentDirection.z * _movingSpeed);
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
        _currentDirection = direction;
        _needMove = true;
    }

    public void SetNoNeedMove()
    {
        _needMove = false;
        _rigidbody.velocity = Vector3.zero;
    }

    private IEnumerator PushingButton(Vector3 direction)
    {
        _rigidbody.velocity = Vector3.zero;
        _movingSpeed = 0;
        _isPushingButton = true;
        Vector3 newDirection = new Vector3(direction.x, transform.position.y, direction.z);
        transform.LookAt(newDirection);
        yield return new WaitForSeconds(PushingDelay);
        _isPushingButton = false;
        _movingSpeed = _startSpeed;
    }
}
