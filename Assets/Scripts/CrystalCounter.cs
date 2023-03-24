using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CrystalCounter : MonoBehaviour
{
    [SerializeField] private CrystalCollector _player;
    [SerializeField] private  TextMeshProUGUI _text;

    private void OnEnable()
    {
        _player.CrystalAdded += OnCrystalAdded;
    }
    private void OnDisable()
    {
        _player.CrystalAdded -= OnCrystalAdded;

    }

    private void OnCrystalAdded(int count)
    {
        _text.text = count.ToString();
    }
}
