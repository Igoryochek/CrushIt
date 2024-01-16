using Crystals;
using UnityEngine;

namespace Counter
{
    public class CrystalCounter : MenuCrystalCounter
    {
        [SerializeField] private CrystalCollector _player;

        private void OnEnable()
        {
            _player.CrystalAdded += OnCrystalAdded;
        }

        private void OnDisable()
        {
            _player.CrystalAdded -= OnCrystalAdded;
        }

        public override void OnCrystalAdded(int count)
        {
            base.OnCrystalAdded(count);

            if (Starting == false)
            {
                EarnedCrystals += count;
            }
        }
    }
}