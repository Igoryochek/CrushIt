using System.Collections;
using Environment;
using PlayerMain;
using UnityEngine;

namespace Movement
{
    public class PlayerMover : Mover
    {
        private const float PushingDelay = 1.5f;
        private const float ZeroSpeed = 0f;

        [SerializeField] private PlayerInput _playerInput;

        private bool _needMove = false;
        private bool _isPushingButton = false;
        private bool _isFirstTimePushingButton = true;
        private Coroutine _pushingButton;

        private void OnEnable()
        {
            _playerInput.JoystickPulled += OnJoystickPulled;
            _playerInput.JoystickPushed += OnJoystickPushed;
        }

        private void OnDisable()
        {
            _playerInput.JoystickPulled -= OnJoystickPulled;
            _playerInput.JoystickPushed -= OnJoystickPushed;
        }

        private void Start()
        {
            if (PlayerPrefs.HasKey(PlayerPrefsKeys.PlayerSpeed))
            {
                Speed = PlayerPrefs.GetInt(PlayerPrefsKeys.PlayerSpeed);
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out SecretSwitch secretSwitch))
            {
                if (_pushingButton == null && _isFirstTimePushingButton)
                {
                    AnimatorController.PushButton();
                    _pushingButton = StartCoroutine(PushingButton(secretSwitch.transform.position));
                    Rotate(secretSwitch.transform.position);
                    _isFirstTimePushingButton = false;
                }
            }
        }

        public override void Move()
        {
            if (_needMove == false && _isPushingButton)
            {
                if (Shooter.IsShooting == false)
                {
                    AnimatorController.StopRun();
                    return;
                }

                AnimatorController.Shoot();
                return;
            }

            AnimatorController.Run();
            Rigidbody.velocity = new Vector3(CurrentDirection.x * MovingSpeed, Rigidbody.velocity.y, CurrentDirection.z * MovingSpeed);

            if (Shooter.IsShooting == false)
            {
                Vector3 newDirection = new Vector3(
                    transform.position.x + CurrentDirection.x,
                    transform.position.y,
                    transform.position.z + CurrentDirection.z);
                Rotate(newDirection);
                return;
            }

            Rotate(Shooter.Target.transform.position);
        }

        public void SetNeedMove(Vector3 direction)
        {
            CurrentDirection = direction;
            _needMove = true;
        }

        public void SetNoNeedMove()
        {
            _needMove = false;
            Rigidbody.velocity = Vector3.zero;
        }

        private void OnJoystickPulled()
        {
            SetNoNeedMove();
        }

        private void OnJoystickPushed(Vector3 direction)
        {
            SetNeedMove(direction);
        }

        private IEnumerator PushingButton(Vector3 direction)
        {
            WaitForSeconds waitForSeconds = new WaitForSeconds(PushingDelay);
            Rigidbody.velocity = Vector3.zero;
            Speed = ZeroSpeed;
            _isPushingButton = true;
            Vector3 newDirection = new Vector3(direction.x, transform.position.y, direction.z);
            transform.LookAt(newDirection);
            yield return waitForSeconds;
            _isPushingButton = false;
            Speed = StartSpeed;
        }
    }
}