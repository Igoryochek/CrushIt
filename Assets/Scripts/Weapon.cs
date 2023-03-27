using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    [SerializeField] private Transform _shootPoint;
    [SerializeField] protected ParticleSystem _particle;
    [SerializeField] protected Bullet Bullet;

    public abstract void Shoot(Health target);

}
