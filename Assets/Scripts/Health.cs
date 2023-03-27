using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(AnimatorController))]
public abstract class Health : MonoBehaviour
{
    [SerializeField] private int _maxHealth;

    private int _currentHealth;
    private bool _isDead=false;

    protected AnimatorController _animatorController;

    public bool IsDead => _isDead;

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
            _isDead = true;
        }
    }

    public void Heal(int count)
    {
        _currentHealth += count;
        if (_currentHealth >= _maxHealth)
        {
            _currentHealth = _maxHealth;
        }
        float currentHealthByMaxHealth = (float)_currentHealth / _maxHealth;
        HealthChanged?.Invoke(currentHealthByMaxHealth);
    }

    public abstract void Die();
}
