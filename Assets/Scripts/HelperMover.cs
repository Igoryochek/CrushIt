using System.Collections;
using UnityEngine;

public class HelperMover : Mover
{
    [SerializeField] private float _obstacleDictance;
    [SerializeField] private float _fromPlayerDictance;
    [SerializeField] private float _zOffset = 3f;
    [SerializeField] private float _xOffset = 3f;
    [SerializeField] private float _delay;
    [SerializeField] private Transform _player;
    [SerializeField] private LayerMask _layerMask;

    private bool _needUp = true;
    private bool _wallCollision = false;

    private const float MaximumRandomChanceValue = 100f;
    private const float NearMaximumRandomChanceValue = 95f;
    private const float MaximumAngleYValue = 110f;

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out Wall wall))
        {
            if (_wallCollision == false)
            {
                _wallCollision = true;
            }

            Rotate(_player.position);
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out Wall wall))
        {
            _wallCollision = false;
        }
    }

    public override void Move()
    {
        if (_needUp == false && _shooter.IsShooting == false)
        {
            _animatorController.Run();

            if (_player != null && Vector3.Distance(_player.position, transform.position) > _fromPlayerDictance)
            {
                float randomZ = Random.Range(-_zOffset, _zOffset);
                float randomX = Random.Range(-_xOffset, _xOffset);
                Rotate(new Vector3(_player.position.x + randomX, _player.position.y, _player.position.z + randomZ));
            }

            _rigidbody.MovePosition(transform.position + transform.forward * _movingSpeed * Time.deltaTime);
            Ray ray = new Ray(transform.position, transform.forward);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, _stopMovingDistance, _layerMask))
            {
                float randomChance = Random.Range(0, MaximumRandomChanceValue);

                if (hit.distance < _obstacleDictance || randomChance > NearMaximumRandomChanceValue)
                {
                    float angleY = Random.Range(-MaximumAngleYValue, MaximumAngleYValue);
                    Vector3 newAngle = new Vector3(0, angleY, 0);
                    transform.eulerAngles = newAngle;
                }
            }
        }
        else
        {
            _rigidbody.velocity = Vector3.zero;
            _animatorController.StopRunAndShoot();
        }
    }

    public void Starting()
    {
        _needUp = true;
        _animatorController.StandUp();
        StartCoroutine(StartDelay());
    }

    private IEnumerator StartDelay()
    {
        yield return new WaitForSeconds(_delay);
        _animatorController.StopStandUp();
        yield return new WaitForSeconds(_delay);
        _needUp = false;
    }
}
