using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CrystalCollector : MonoBehaviour
{
    public event UnityAction<int> CrystalAdded;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out CrystalMine crystalMine))
        {
            Debug.Log("hier");
            AddCrystal(crystalMine.Count);
            crystalMine.MoveToCollect(this);
        }
    }

    private void AddCrystal(int crystalsCount)
    {
        CrystalAdded?.Invoke(crystalsCount);

    }
}
