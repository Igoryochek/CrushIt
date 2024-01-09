using UnityEngine;

public class Ship : MonoBehaviour
{
    [SerializeField] private GameObject _panelToOpen;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out Player player))
        {
            OpenPanel();
        }
    }

    public void OpenPanel()
    {
        _panelToOpen.SetActive(true);
    }
}
