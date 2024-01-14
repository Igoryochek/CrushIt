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

        protected bool _starting = true;
        protected int _earnedCrystals;

        [SerializeField] private TextMeshProUGUI _text;

        private int _crystalsCount;

        public int CrystalsCount => _crystalsCount;
        public int EarnedCrystals => _earnedCrystals;

        private void Start()
        {
            if (PlayerPrefs.HasKey(PlayerPrefsKeys.CrystalsCount))
            {
                AddCrystals(PlayerPrefs.GetInt(PlayerPrefsKeys.CrystalsCount));
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
            PlayerPrefs.SetInt(PlayerPrefsKeys.CrystalsCount, _crystalsCount);
        }

        public void MultyplyEarnedCrystals()
        {
            AddCrystals(_earnedCrystals);
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
