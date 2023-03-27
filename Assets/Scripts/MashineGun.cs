using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MashineGun : Weapon
{
    [SerializeField] private int _bulletsCountInTime;

    private int _startCount;
    public override void Shoot(Health target)
    {
        StartCoroutine(Shooting(target));
    }

    private void Start()
    {
        _startCount = _bulletsCountInTime;
    }

    private IEnumerator Shooting(Health target)
    {
        _bulletsCountInTime = _startCount;
        WaitForSeconds waitForSeconds=new WaitForSeconds(0.2f);
        while (_bulletsCountInTime!=0)
        {
            _particle.Play();
            Bullet bullet = Instantiate(Bullet, transform.position, Quaternion.identity);
            bullet.MoveTo(target.transform);
            _bulletsCountInTime -= 1;
            yield return waitForSeconds;
            yield return null;
        }
    }
}
