using UnityEngine;

[RequireComponent(typeof(PlayerMover))]

public class PlayerInput : MonoBehaviour
{
    [SerializeField] private VariableJoystick _joystick;

    private PlayerMover _mover;
    private bool _isMobile = false;

    private const float One = 1f;

    private void Start()
    {
        _mover = GetComponent<PlayerMover>();

        if (Application.isMobilePlatform)
        {
            _isMobile = true;
            if (_joystick.gameObject.activeSelf == false)
            {
                _joystick.gameObject.SetActive(true);
            }
        }
    }

    private void Update()
    {
        if (_isMobile)
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
        else
        {
            if (Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.W) ||
                Input.GetKey(KeyCode.RightArrow) && Input.GetKey(KeyCode.UpArrow))
            {
                _mover.SetNeedMove(new Vector3(One, 0, One));
            }
            else if (Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.S) ||
                Input.GetKey(KeyCode.RightArrow) && Input.GetKey(KeyCode.DownArrow))
            {
                _mover.SetNeedMove(new Vector3(One, 0, -One));
            }
            else if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.W) ||
                Input.GetKey(KeyCode.LeftArrow) && Input.GetKey(KeyCode.UpArrow))
            {
                _mover.SetNeedMove(new Vector3(-One, 0, One));
            }
            else if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.S) ||
                Input.GetKey(KeyCode.LeftArrow) && Input.GetKey(KeyCode.DownArrow))
            {
                _mover.SetNeedMove(new Vector3(-One, 0, -One));
            }
            else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            {
                _mover.SetNeedMove(Vector3.right);
            }
            else if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            {
                _mover.SetNeedMove(Vector3.left);
            }
            else if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
            {
                _mover.SetNeedMove(Vector3.forward);
            }
            else if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
            {
                _mover.SetNeedMove(Vector3.back);
            }
            else
            {
                _mover.SetNoNeedMove();
            }
        }
    }
}
