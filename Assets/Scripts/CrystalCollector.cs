using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CrystalCollector : MonoBehaviour
{
    private int _crystalsCount;

    public event UnityAction<int> CrystalAdded;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out CrystalMineMover crystalMine))
        {
            AddCrystal();
            crystalMine.MoveToCollect(transform);
        }
    }

    private void AddCrystal()
    {
        _crystalsCount += 10;
        CrystalAdded?.Invoke(_crystalsCount);
    }
}
