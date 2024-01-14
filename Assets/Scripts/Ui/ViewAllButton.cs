using CameraController;
using UnityEngine;

namespace UI
{
    public class ViewAllButton : MonoBehaviour
    {
        [SerializeField] private CameraMovement _cameraMovement;

        public void ViewAll()
        {
            _cameraMovement.ViewAll();
        }
    }
}
