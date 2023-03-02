using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(AnimatorController))]
public abstract class Health : MonoBehaviour
{
    [SerializeField] private int _maxHealth;

    private int _currentHealth;

    protected AnimatorController _animatorController;

    public event UnityAction<float> HealthChanged;

    private void Start()
    {
        _currentHealth = _maxHealth;
        _animatorController = GetComponent<AnimatorController>();
    }

    public void TakeDamage(int count)
    {
        _currentHealth -= count;
        float currentHealthByMaxHealth = (float)_currentHealth / _maxHealth;
        HealthChanged?.Invoke(currentHealthByMaxHealth);

        if (_currentHealth <= 0)
        {
            Die();
        }
    }

    public abstract void Die();
}
