using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMover))]
public class PlayerInput : MonoBehaviour
{
    [SerializeField] private VariableJoystick _joystick;

    private PlayerMover _mover;

    private void Start()
    {
        _mover = GetComponent<PlayerMover>();
    }

    private void Update()
    {
        Vector3 newDirection = new Vector3(_joystick.Horizontal,
            transform.position.y, _joystick.Vertical);
        if (_joystick.Horizontal != 0 && _joystick.Vertical != 0)
        {
            
            _mover.SetNeedMove(newDirection);
        }
        else
        {
            _mover.SetNoNeedMove();

        }
    }
}
