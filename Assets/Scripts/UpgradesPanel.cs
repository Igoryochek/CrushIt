using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradesPanel : MonoBehaviour
{
    [SerializeField] private UpgradeButton[] _upgradeButtons;
    private void OnEnable()
    {
        StartCoroutine(Renewing());
    }

    private IEnumerator Renewing()
    {
        yield return new WaitForSeconds(0.2f);
        foreach (var button in _upgradeButtons)
        {
            button.Renew();
        }
    }
}
