using TMPro;
using UnityEngine;

namespace Counter
{
    public class MenuCrystalCounter : MonoBehaviour
    {
        private const int NearThousend = 999;
        private const int Thousend = 1000;
        private const int ReminderDivider = 10;
        private const string LetterK = "K";
        private const string Dot = ".";

        protected bool Starting = true;
        protected int EarnedCrystals;

        [SerializeField] private TextMeshProUGUI _text;

        private int _crystalsCount;

        public int CrystalsCount => _crystalsCount;

        public int CurrentEarnedCrystals => EarnedCrystals;

        private void Start()
        {
            if (PlayerPrefs.HasKey(PlayerPrefsKeys.CrystalsCount))
            {
                OnCrystalAdded(PlayerPrefs.GetInt(PlayerPrefsKeys.CrystalsCount));
            }

            Starting = false;
        }

        public virtual void OnCrystalAdded(int count)
        {
            _crystalsCount += count;
            ShowCount();
        }

        public void AddCrystalsForAd(int count)
        {
            OnCrystalAdded(count);
            PlayerPrefs.SetInt(PlayerPrefsKeys.CrystalsCount, _crystalsCount);
        }

        public void MultyplyEarnedCrystals()
        {
            OnCrystalAdded(CurrentEarnedCrystals);
        }

        public void RemoveCrystals(int count)
        {
            _crystalsCount -= count;
            PlayerPrefs.SetInt(PlayerPrefsKeys.CrystalsCount, _crystalsCount);
            ShowCount();
        }

        private void ShowCount()
        {
            if (_crystalsCount <= NearThousend)
            {
                _text.text = _crystalsCount.ToString();
                return;
            }

            int count = _crystalsCount / Thousend;
            int reminder = (_crystalsCount - (Thousend * count)) / ReminderDivider;

            if (reminder != 0)
            {
                string newTextWithReminder = count.ToString() + Dot + reminder + LetterK;
                _text.text = newTextWithReminder;
                return;
            }

            string newText = count.ToString() + LetterK;
            _text.text = newText;
        }
    }
}