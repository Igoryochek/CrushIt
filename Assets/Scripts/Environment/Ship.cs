using UnityEngine;

namespace Environment
{
    public class Ship : MonoBehaviour
    {
        [SerializeField] private GameObject _panelToOpen;

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.TryGetComponent(out Player.Player player))
            {
                OpenPanel();
            }
        }

        public void OpenPanel()
        {
            _panelToOpen.SetActive(true);
        }
    }
}
