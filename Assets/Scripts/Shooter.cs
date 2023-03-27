using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[RequireComponent(typeof(Health))]

public class Shooter : MonoBehaviour
{
    [SerializeField] private Weapon _weapon;
    [SerializeField] private float _timeBetweenShoot;
    [SerializeField] private float _shootingDistance;
    [SerializeField] private float _stopShootingDistance;
    [SerializeField] private Transform _headPoint;
    [SerializeField] private LayerMask _layerMask;

    private Coroutine _shooting;
    private bool _isShooting = false;
    private Health _currentTarget;
    private Health _selfHealth;

    public Health Target => _currentTarget;

    public bool IsShooting => _isShooting;

    private void Start()
    {
        _selfHealth = GetComponent<Health>();
    }

    private void Update()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, _shootingDistance,_layerMask);
        foreach (var collider in colliders)
        {
            if (collider.gameObject.TryGetComponent(out Health health))
            {
                if (health.IsDead==false&&health.gameObject != gameObject&& _shooting == null)
                {
                    Shoot(health);
                    return;
                }
            }
        } 
    }

    private void Shoot(Health target)
    {
            _currentTarget = target;
            _isShooting = true;
            _shooting = StartCoroutine(Shooting(_currentTarget));
        
    }

    private void StopShoot()
    {
        if (_shooting!=null)
        {
            StopCoroutine(_shooting);
            _isShooting = false;
            _shooting = null;
            _currentTarget = null;
        }

    }

    private IEnumerator Shooting(Health target)
    {
        
        while (_selfHealth.IsDead==false&&_currentTarget!=null
            && target.IsDead==false && Vector3.Distance(_currentTarget.transform.position, transform.position) < _stopShootingDistance)
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
