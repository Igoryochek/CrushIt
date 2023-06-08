using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : Health
{
    [SerializeField] private GameObject _gameOverPanel;
    public override void Die()
    {
        _animatorController.Die();
        StartCoroutine(Dying());
    }

    private IEnumerator Dying()
    {
        yield return new WaitForSeconds(2);
        _gameOverPanel.SetActive(true);
    }

    public void RiseUp()
    {
        _animatorController.RisingUp();
        _isDead = false;
        Heal(100);
    }
}
