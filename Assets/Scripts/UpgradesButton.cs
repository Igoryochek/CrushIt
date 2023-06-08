using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradesButton : MonoBehaviour
{
    [SerializeField] private GameObject _panelToOpen;

    public void OpenPanel()
    {
        _panelToOpen.SetActive(true);
    }

    public void ClosePanel()
    {
        _panelToOpen.SetActive(false);
    }
}