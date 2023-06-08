using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MenuCrystalCounter : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;

    private int _crystalsCount;
    protected bool _starting=true;
    protected int _earnedCrystals;

    public int CrystalsCount => _crystalsCount;
    public int EarnedCrystals => _earnedCrystals;

    private void Start()
    {
        if (PlayerPrefs.HasKey("CrystalsCount"))
        {
            AddCrystals(PlayerPrefs.GetInt("CrystalsCount"));
        }
        _starting = false;
    }

    public virtual void AddCrystals(int count)
    {
        _crystalsCount += count;
        ShowCount();
    }

    public void AddCrystalsForAd(int count)
    {
        AddCrystals(count);
        PlayerPrefs.SetInt("CrystalsCount", _crystalsCount);
    }
    
    public void MultyplyEarnedCrystals()
    {
        AddCrystals(_earnedCrystals);
    }
    public void RemoveCrystals(int count)
    {
        _crystalsCount -= count;
        PlayerPrefs.SetInt("CrystalsCount", _crystalsCount);
        ShowCount();
    }

    private void ShowCount()
    {
        if (_crystalsCount>999)
        {
            int count = _crystalsCount / 1000;
            int reminder =( _crystalsCount - (1000*count))/10;
            if (reminder==0)
            {
                _text.text = count.ToString()+"K";
            }
            else
            {
                _text.text = count.ToString()+"."+reminder + "K";
            }
        }
        else
        {
            _text.text = _crystalsCount.ToString();
        }

    }
}
