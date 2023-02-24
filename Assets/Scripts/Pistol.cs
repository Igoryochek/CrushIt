using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : Weapon
{
    public override void Shoot(Transform target)
    {
        Bullet bullet = Instantiate(Bullet, transform.position, Quaternion.identity);
        Vector3 targetPosition= target.position;
        bullet.MoveTo(targetPosition);
    }
}
