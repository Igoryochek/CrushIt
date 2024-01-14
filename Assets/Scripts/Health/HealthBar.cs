using UnityEngine;
using UnityEngine.UI;

namespace GeneralHealth
{
    public class HealthBar : MonoBehaviour
    {
        private const float RotationAngleX = 0;
        private const float RotationAngleY = 180f;
        private const float RotationAngleZ = 0;

        [SerializeField] private Slider _slider;
        [SerializeField] private Health _health;

        private Camera _camera;

        private void OnEnable()
        {
            _health.HealthChanged += OnHealthChanged;
        }

        private void OnDisable()
        {
            _health.HealthChanged -= OnHealthChanged;
        }

        private void Start()
        {
            _camera = UnityEngine.Camera.main;
        }

        private void LateUpdate()
        {
            transform.LookAt(new Vector3(transform.position.x, _camera.transform.position.y, _camera.transform.position.z));
            transform.Rotate(RotationAngleX, RotationAngleY, RotationAngleZ);
        }

        private void OnHealthChanged(float count)
        {
            _slider.value = count;
        }
    }
}
