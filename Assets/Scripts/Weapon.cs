using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    [SerializeField] protected Bullet _bulletPrefab;
    [SerializeField] protected ParticleSystem _particle;
    [SerializeField] protected AudioSource _audioSource;
    [SerializeField] protected string _savingName;

    protected Shooter _shooter;
    protected float _bulletSpeed;
    protected int _damage;

    private void Start()
    {
        _shooter = GetComponentInParent<Shooter>();
        _bulletSpeed = _shooter.BulletSpeed();
        _damage = _shooter.Damage;

        if (PlayerPrefs.HasKey(_savingName))
        {
            _damage = PlayerPrefs.GetInt(_savingName);
        }
    }

    public abstract void Shoot(Health target);
}
