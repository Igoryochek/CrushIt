using Counter;
using TMPro;
using UnityEngine;

namespace UI
{
    public class UpgradeButton : MonoBehaviour
    {
        private const float Offset = 0.1f;
        private const string PlusSign = "+";
        private const string SpaceSign = " ";

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

        public void RenewData()
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

            ShowData(savingName);
        }

        public void BuyUpgrade()
        {
            if (_counter.CrystalsCount >= _price)
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
                _descriptionText.text = PlusSign + _upgradeValue.ToString() + SpaceSign + _startDescription +
                    PlayerPrefs.GetInt(_savingName).ToString();
                _price += (int)((float)_price * Offset);
                _crystalsPriceText.text = _startPriceText + _price.ToString();
                PlayerPrefs.SetInt(_savingPrice, _price);
            }
        }

        public void ShowData(int savingName)
        {
            string newPriceText = _startPriceText + _price.ToString();
            _crystalsPriceText.text = newPriceText;
            string newDescriptionText = PlusSign + _upgradeValue.ToString() + SpaceSign + _startDescription + savingName.ToString();
            _descriptionText.text = newDescriptionText;
        }
    }
}

