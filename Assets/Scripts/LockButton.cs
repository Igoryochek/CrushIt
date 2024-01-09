using UnityEngine;

public class LockButton : MonoBehaviour
{
    [SerializeField] private LockPanel _panelToOpen;
    [SerializeField] private int _price;
    [SerializeField] private int _planetNumber;

    public int Price => _price;
    public int PlanetNumber => _planetNumber;


    private void Start()
    {
        if (PlayerPrefs.HasKey("LockButton" + _planetNumber + "Off"))
        {
            gameObject.SetActive(false);
        }
    }

    public void OpenPanel()
    {
        _panelToOpen.SetCurrentLockButton(this);
        _panelToOpen.gameObject.SetActive(true);
    }
}
