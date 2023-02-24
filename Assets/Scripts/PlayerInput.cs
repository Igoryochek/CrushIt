using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PLayerMover))]

public class PlayerInput : MonoBehaviour
{
    [SerializeField] private VariableJoystick _joystick;

    private PLayerMover _mover;

    private void Start()
    {
        _mover = GetComponent<PLayerMover>();
    }

    private void Update()
    {
        Vector3 newDirection = new Vector3(transform.position.x + _joystick.Horizontal * _mover.MovingSpeed * Time.deltaTime,
            transform.position.y, transform.position.z + _joystick.Vertical * _mover.MovingSpeed * Time.deltaTime);
        if (_joystick.Horizontal != 0 && _joystick.Vertical != 0)
        {
            _mover.Move(newDirection);
        }
    }
}
