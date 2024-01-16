using System;
using Movement;
using UnityEngine;

namespace PlayerMain
{
    [RequireComponent(typeof(PlayerMover))]

    public class PlayerInput : MonoBehaviour
    {
        private const float ZeroValue = 0f;

        [SerializeField] private VariableJoystick _joystick;

        public event Action<Vector3> JoystickPushed;

        public event Action JoystickPulled;

        private void Start()
        {
            if (_joystick.gameObject.activeSelf == false)
            {
                _joystick.gameObject.SetActive(true);
            }
        }

        private void Update()
        {
            Vector3 newDirection = new Vector3(_joystick.Horizontal, transform.position.y, _joystick.Vertical);

            if (_joystick.Horizontal == ZeroValue && _joystick.Vertical == ZeroValue)
            {
                JoystickPulled?.Invoke();
                return;
            }

            JoystickPushed?.Invoke(newDirection);
        }
    }
}