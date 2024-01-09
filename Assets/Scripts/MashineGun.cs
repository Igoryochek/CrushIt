using System.Collections;
using UnityEngine;

public class MashineGun : Weapon
{
    [SerializeField] private int _bulletsCountInTime;
    [SerializeField] private float _delay = 0.2f;

    private int _startCount;


    private void Start()
    {
        _startCount = _bulletsCountInTime;
    }

    public override void Shoot(Health target)
    {
        StartCoroutine(Shooting(target));
    }

    private IEnumerator Shooting(Health target)
    {
        _bulletsCountInTime = _startCount;
        WaitForSeconds waitForSeconds = new WaitForSeconds(_delay);

        while (_bulletsCountInTime != 0)
        {
            _particle.Play();
            target.TakeDamage(_damage);
            _bulletsCountInTime--;
            yield return waitForSeconds;
            yield return null;
        }
    }
}
