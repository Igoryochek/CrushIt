using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CrystalCounter : MenuCrystalCounter
{
    [SerializeField] private CrystalCollector _player;



    private void OnEnable()
    {
        _player.CrystalAdded += AddCrystals;

    }
    private void OnDisable()
    {
        _player.CrystalAdded -= AddCrystals;

    }

    public override void AddCrystals(int count)
    {
        base.AddCrystals(count);
        if (_starting==false)
        {
            _earnedCrystals += count;
        }
    }     

}
