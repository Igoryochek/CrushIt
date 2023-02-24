using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Crystal : MonoBehaviour,IShootable
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
