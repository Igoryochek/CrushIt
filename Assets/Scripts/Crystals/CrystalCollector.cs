using System;
using UnityEngine;

namespace Crystals
{
    public class CrystalCollector : MonoBehaviour
    {
        public event Action<int> CrystalAdded;

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out CrystalMine crystalMine))
            {
                AddCrystal(crystalMine.Count);
                crystalMine.MoveToCollect(this);
            }
        }

        private void AddCrystal(int crystalsCount)
        {
            CrystalAdded?.Invoke(crystalsCount);
        }
    }
}