using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Health))]

public class Shooter : MonoBehaviour
{
    [SerializeField] private Weapon _weapon;
    [SerializeField] private float _timeBetweenShoot;
    [SerializeField] private float _bulletSpeed;
    [SerializeField] private int _damage;
    [SerializeField] private float _shootingDistance;
    [SerializeField] private float _stopShootingDistance;
    [SerializeField] private LayerMask _layerMask;

    private Coroutine _shooting;
    private bool _isShooting = false;
    private Health _currentTarget;
    private Health _selfHealth;

    public Health Target => _currentTarget;
    public int Damage => _damage;
    public bool IsShooting => _isShooting;

    private void Start()
    {
        if ((gameObject.TryGetComponent(out Player player) || gameObject.TryGetComponent(out Helper helper))
            && PlayerPrefs.HasKey("PlayerBulletSpeed"))
        {
            _bulletSpeed = PlayerPrefs.GetInt("PlayerBulletSpeed");
        }

        _selfHealth = GetComponent<Health>();
    }

    private void Update()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, _shootingDistance, _layerMask);
        foreach (var collider in colliders)
        {
            if (collider.gameObject.TryGetComponent(out Health health))
            {
                if (health.IsDead == false && health.gameObject != gameObject && _shooting == null)
                {
                    Shoot(health);
                    return;
                }
            }
        }
    }
    public float BulletSpeed()
    {
        float speed;
        if ((gameObject.TryGetComponent(out Player player) || gameObject.TryGetComponent(out Helper helper))
            && PlayerPrefs.HasKey("PlayerBulletSpeed"))
        {
            speed = PlayerPrefs.GetInt("PlayerBulletSpeed");
        }
        else
        {
            speed = _bulletSpeed;
        }

        return speed;
    }

    private void Shoot(Health target)
    {
        _currentTarget = target;
        _isShooting = true;
        _shooting = StartCoroutine(Shooting(_currentTarget));
    }

    private void StopShoot()
    {
        if (_shooting != null)
        {
            StopCoroutine(_shooting);
            _isShooting = false;
            _shooting = null;
            _currentTarget = null;
        }
    }

    private IEnumerator Shooting(Health target)
    {
        while (_selfHealth.IsDead == false && _currentTarget != null
            && target.IsDead == false && Vector3.Distance(_currentTarget.transform.position, transform.position) < _stopShootingDistance)
        {
            _weapon.Shoot(_currentTarget);
            yield return null;
            yield return new WaitForSeconds(_timeBetweenShoot);
        }

        _isShooting = false;
        _shooting = null;
        _currentTarget = null;
    }
}
