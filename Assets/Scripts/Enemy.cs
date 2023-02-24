using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, IShootable
{
    [SerializeField] private int _health;

    public void TakeDamage(int count)
    {
        _health -= count;
        if (_health <= 0)
        {
            gameObject.SetActive(false);
        }
    }
}