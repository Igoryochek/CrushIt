using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContinueButton : MonoBehaviour
{
    [SerializeField] private GameObject _panelToClose;

    public void ClosePanel()
    {
        _panelToClose.SetActive(false);
    }
}
