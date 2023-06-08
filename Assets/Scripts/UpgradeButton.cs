using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UpgradeButton : MonoBehaviour
{
    [SerializeField] private MenuCrystalCounter _counter;
    [SerializeField] private TextMeshProUGUI _crystalsPriceText;
    [SerializeField] private TextMeshProUGUI _descriptionText;
    [SerializeField] private int _upgradeValue;
    [SerializeField] private int _price;
    [SerializeField] private int _startValue;
    [SerializeField] private string _savingName;
    [SerializeField] private string _savingPrice;

    private string _startDescription;
    private string _startPriceText;

    public void Renew()
    {
        _startDescription = _descriptionText.text;
        _startPriceText = _crystalsPriceText.text;
        _crystalsPriceText.text += _price;
        int savingName;
        if (PlayerPrefs.HasKey(_savingName))
        {
            savingName = PlayerPrefs.GetInt(_savingName);
        }
        else
        {
            savingName = _startValue;
        }
        if (PlayerPrefs.HasKey(_savingPrice))
        {
            _price = PlayerPrefs.GetInt(_savingPrice);
        }
        _crystalsPriceText.text = _startPriceText + _price.ToString();
        _descriptionText.text = "+" + _upgradeValue.ToString() + " " + _startDescription + savingName.ToString();
    }

    public void BuyUpgrade()
    {
        if (_counter.CrystalsCount>=_price)
        {
            if (PlayerPrefs.HasKey(_savingName))
            {
                PlayerPrefs.SetInt(_savingName, PlayerPrefs.GetInt(_savingName) + _upgradeValue);
            }
            else
            {
                PlayerPrefs.SetInt(_savingName, _startValue + _upgradeValue);
            }

            _counter.RemoveCrystals(_price);
            _descriptionText.text = "+" + _upgradeValue.ToString() + " " + _startDescription + PlayerPrefs.GetInt(_savingName).ToString();
            _price +=(int)((float)_price* 0.1f);
            _crystalsPriceText.text =_startPriceText+ _price.ToString();
            PlayerPrefs.SetInt(_savingPrice,_price);
        }
    }
}
