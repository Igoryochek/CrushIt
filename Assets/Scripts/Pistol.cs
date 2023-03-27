using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : Weapon
{

    public override void Shoot(Health target)
    {
        _particle.Play();
        Bullet bullet = Instantiate(Bullet, transform.position, Quaternion.identity);
        bullet.MoveTo(target.transform);

    }
}
