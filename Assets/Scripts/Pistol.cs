using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : Weapon
{
    public override void Shoot(Health target)
    {

        _particle.Play();
        _audioSource.Play();
        Bullet bullet=Instantiate(_bulletPrefab,transform.position,Quaternion.identity);
        bullet.SetSpeed(_bulletSpeed);
        bullet.SetDamage(_damage);
        bullet.MoveTo(target.transform);
    }
}
