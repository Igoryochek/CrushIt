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

    private GameObject _hit;
    private Coroutine _shooting;
    [SerializeField]private bool _isShooting = false;
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
        Ray ray = new Ray(transform.position,transform.TransformDirection(Vector3.forward)*10);
        RaycastHit hit;
        if (Physics.Raycast(ray,out hit,_shootingDistance))
        {
            if (hit.transform.gameObject.TryGetComponent(out IShootable shootable))
            {
                if (hit.transform.gameObject.activeSelf&& hit.transform.gameObject!=gameObject)
                {
                    Shoot(hit.transform.gameObject.transform);

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
        if (_shooting==null)
        {
            _currentTarget = target;
            _isShooting = true;
            _shooting = StartCoroutine(Shooting());
        }
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

    private IEnumerator Shooting()
    {
        while (true)
        {
            _weapon.Shoot(_currentTarget);
            yield return null;
            yield return new WaitForSeconds(_timeBetweenShoot);            
        }
    }
}
