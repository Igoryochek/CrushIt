using GeneralHealth;
using UnityEngine;

namespace Shooting
{
    public abstract class Weapon : MonoBehaviour
    {
        [SerializeField] protected Bullet BulletPrefab;
        [SerializeField] protected ParticleSystem Particle;
        [SerializeField] protected AudioSource AudioSource;
        [SerializeField] protected string SavingName;

        protected Shooter Shooter;
        protected float BulletSpeed;
        protected int Damage;

        private void Start()
        {
            Shooter = GetComponentInParent<Shooter>();
            BulletSpeed = Shooter.BulletSpeed();
            Damage = Shooter.Damage;

            if (PlayerPrefs.HasKey(SavingName))
            {
                Damage = PlayerPrefs.GetInt(SavingName);
            }
        }

        public abstract void Shoot(Health target);
    }
}
