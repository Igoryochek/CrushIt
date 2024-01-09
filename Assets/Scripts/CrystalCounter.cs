using UnityEngine;

public class CrystalCounter : MenuCrystalCounter
{
    [SerializeField] private CrystalCollector _player;

    private void OnEnable()
    {
        _player.CrystalAdded += OnCrystalsAdded;
    }

    private void OnDisable()
    {
        _player.CrystalAdded -= OnCrystalsAdded;
    }

    public override void OnCrystalsAdded(int count)
    {
        base.OnCrystalsAdded(count);

        if (_starting == false)
        {
            _earnedCrystals += count;
        }
    }
}
