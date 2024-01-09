using TMPro;
using UnityEngine;

public class MenuCrystalCounter : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;

    private int _crystalsCount;

    private const int NearThousend = 999;
    private const int Thousend = 1000;
    private const int ReminderDivider = 10;


    protected bool _starting = true;
    protected int _earnedCrystals;

    public int CrystalsCount => _crystalsCount;
    public int EarnedCrystals => _earnedCrystals;

    private void Start()
    {
        if (PlayerPrefs.HasKey("CrystalsCount"))
        {
            OnCrystalsAdded(PlayerPrefs.GetInt("CrystalsCount"));
        }

        _starting = false;
    }

    public virtual void OnCrystalsAdded(int count)
    {
        _crystalsCount += count;
        ShowCount();
    }

    public void AddCrystalsForAd(int count)
    {
        OnCrystalsAdded(count);
        PlayerPrefs.SetInt("CrystalsCount", _crystalsCount);
    }

    public void MultyplyEarnedCrystals()
    {
        OnCrystalsAdded(_earnedCrystals);
    }

    public void RemoveCrystals(int count)
    {
        _crystalsCount -= count;
        PlayerPrefs.SetInt("CrystalsCount", _crystalsCount);
        ShowCount();
    }

    private void ShowCount()
    {
        if (_crystalsCount > NearThousend)
        {
            int count = _crystalsCount / Thousend;
            int reminder = (_crystalsCount - (Thousend * count)) / ReminderDivider;

            if (reminder == 0)
            {
                _text.text = count.ToString() + "K";
            }
            else
            {
                _text.text = count.ToString() + "." + reminder + "K";
            }
        }
        else
        {
            _text.text = _crystalsCount.ToString();
        }
    }
}
