using Level;
using System;
using UnityEngine;

namespace GeneralHealth
{
    [RequireComponent(typeof(AnimatorController))]

    public abstract class Health : MonoBehaviour
    {
        private const int ZeroHealth = 0;

        [SerializeField] protected int MaxHealth;
        [SerializeField] protected string SavingName;
        [SerializeField] protected AudioSource AudioSource;

        protected bool IsDeadCondition = false;
        protected int CurrentHealth;
        protected AnimatorController AnimatorController;

        public event Action<float> HealthChanged;

        public bool IsDead => IsDeadCondition;

        private void OnEnable()
        {
            Heal(MaxHealth);

            if (IsDeadCondition)
            {
                IsDeadCondition = false;
            }
        }

        private void Start()
        {
            if (PlayerPrefs.HasKey(SavingName))
            {
                MaxHealth = PlayerPrefs.GetInt(SavingName);
            }

            SetCurrentHealth(MaxHealth);
            AnimatorController = GetComponent<AnimatorController>();
        }

        public void TakeDamage(int count)
        {
            CurrentHealth -= count;
            float currentHealthByMaxHealth = (float)CurrentHealth / MaxHealth;
            HealthChanged?.Invoke(currentHealthByMaxHealth);

            if (CurrentHealth <= ZeroHealth)
            {
                SetCurrentHealth(ZeroHealth);
                Die();
                IsDeadCondition = true;
            }
        }

        public void Heal(int count)
        {
            CurrentHealth += count;

            if (CurrentHealth >= MaxHealth)
            {
                SetCurrentHealth(MaxHealth);
            }

            float currentHealthByMaxHealth = (float)CurrentHealth / MaxHealth;
            HealthChanged?.Invoke(currentHealthByMaxHealth);
        }

        public void Revive()
        {
            IsDeadCondition = false;
            Heal(MaxHealth);
        }

        public abstract void Die();

        private void SetCurrentHealth(int amount)
        {
            CurrentHealth = amount;
        }
    }
}


