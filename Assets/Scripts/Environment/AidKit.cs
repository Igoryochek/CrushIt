using GeneralHealth;
using System.Collections;
using UnityEngine;

namespace Environment
{
    public class AidKit : MonoBehaviour
    {
        private const float RotationAngleX = 0.5f;
        private const float RotationAngleY = 0f;
        private const float RotationAngleZ = 0f;

        [SerializeField] private int _healingValue;
        [SerializeField] private float _delay = 0.2f;
        [SerializeField] private AudioSource _audioSource;

        private void Start()
        {
            if (PlayerPrefs.HasKey(PlayerPrefsKeys.AidKitValue))
            {
                _healingValue = PlayerPrefs.GetInt(PlayerPrefsKeys.AidKitValue);
            }
        }

        private void Update()
        {
            transform.Rotate(RotationAngleX, RotationAngleY, RotationAngleZ);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out PlayerHealth health))
            {
                health.Heal(_healingValue);
                StartCoroutine(Disappearing());
            }
        }

        private IEnumerator Disappearing()
        {
            _audioSource.Play();
            yield return new WaitForSeconds(_delay);
            gameObject.SetActive(false);
        }
    }
}
