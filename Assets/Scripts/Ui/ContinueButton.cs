using UnityEngine;

namespace UI
{
    public class ContinueButton : MonoBehaviour
    {
        [SerializeField] private GameObject _panelToClose;

        public void ClosePanel()
        {
            _panelToClose.SetActive(false);
        }
    }
}
