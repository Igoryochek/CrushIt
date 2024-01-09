using System.Collections;
using UnityEngine;

public class AidKit : MonoBehaviour
{
    [SerializeField] private int _healingValue;
    [SerializeField] private AudioSource _audioSource;

    private const float RotationAngleX = 0.5f;

    private void Start()
    {
        if (PlayerPrefs.HasKey("AidKitValue"))
        {
            _healingValue = PlayerPrefs.GetInt("AidKitValue");
        }
    }

    private void Update()
    {
        transform.Rotate(RotationAngleX, 0, 0);
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
        yield return new WaitForSeconds(0.2f);
        gameObject.SetActive(false);
    }
}
