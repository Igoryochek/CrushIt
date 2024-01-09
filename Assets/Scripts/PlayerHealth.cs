using System.Collections;
using UnityEngine;

public class PlayerHealth : Health
{
    [SerializeField] private GameObject _gameOverPanel;
    [SerializeField] private float _delay = 2f;
    [SerializeField] private int _additiveHealth = 100;

    public override void Die()
    {
        _animatorController.Die();
        StartCoroutine(Dying());
    }

    private IEnumerator Dying()
    {
        yield return new WaitForSeconds(_delay);
        _gameOverPanel.SetActive(true);
    }

    public void RiseUp()
    {
        _animatorController.RisingUp();
        _isDead = false;
        Heal(_additiveHealth);
    }
}
