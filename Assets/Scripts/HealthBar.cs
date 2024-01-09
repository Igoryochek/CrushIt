using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    [SerializeField] private Health _health;

    private Camera _camera;

    private const float RotationAngleY = 180f;

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
        _camera = Camera.main;
    }

    private void LateUpdate()
    {
        transform.LookAt(new Vector3(transform.position.x, _camera.transform.position.y, _camera.transform.position.z));
        transform.Rotate(0, RotationAngleY, 0);
    }

    private void OnHealthChanged(float count)
    {
        _slider.value = count;
    }
}
