using GeneralHealth;
using UnityEngine;

namespace Shooting
{
    public class Pistol : Weapon
    {
        public override void Shoot(Health target)
        {
            Particle.Play();
            AudioSource.Play();
            Bullet bullet = Instantiate(BulletPrefab, transform.position, Quaternion.identity);
            bullet.SetSpeed(BulletSpeed);
            bullet.SetDamage(Damage);
            bullet.MoveTo(target.transform);
        }
    }
}

