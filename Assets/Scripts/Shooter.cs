using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;



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
    private Transform _currentTarget;
    private IShootable _shootable;

    public Transform Target => _currentTarget;

    public bool IsShooting => _isShooting;

    private void Start()
    {
        _shootable = GetComponent<IShootable>();
    }

    private void Update()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, _shootingDistance,_layerMask);
        foreach (var collider in colliders)
        {
            if (collider.gameObject.TryGetComponent(out Health health))
            {
                if (collider.gameObject != gameObject&& _shooting == null)
                {
                    Shoot(collider.gameObject.transform);
                    return;
                }
            }
        } 
        

        
        if (_currentTarget!=null&&_currentTarget.gameObject.activeSelf==false)
        {
            StopShoot();
        }
        else if (_currentTarget != null &&Vector3.Distance(_currentTarget.position,transform.position)>_stopShootingDistance)
        {
            StopShoot();
        }
    }

    private void Shoot(Transform target)
    {
            _currentTarget = target;
            _isShooting = true;
            _shooting = StartCoroutine(Shooting(target));
        
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

    private IEnumerator Shooting(Transform target)
    {
        while (target.gameObject.activeSelf)
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
