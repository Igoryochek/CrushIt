using UnityEngine;

public class ViewAllButton : MonoBehaviour
{
    [SerializeField] private CameraMovement _cameraMovement;

    public void ViewAll()
    {
        _cameraMovement.ViewAll();
    }
}
