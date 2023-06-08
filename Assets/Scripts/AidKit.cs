using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AidKit : MonoBehaviour
{
    [SerializeField] private int _healingValue;
    [SerializeField] private AudioSource _audioSource;

    private void Start()
    {
        if (PlayerPrefs.HasKey("AidKitValue"))
        {
            _healingValue = PlayerPrefs.GetInt("AidKitValue");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out PlayerHealth health))
        {
            health.Heal(_healingValue);
            StartCoroutine(Dying());
        }
    }

    private void Update()
    {
        transform.Rotate(0.5f,0,0);
    }

    private IEnumerator Dying()
    {
        _audioSource.Play();
        yield return new WaitForSeconds(0.2f);
        gameObject.SetActive(false);
    }
}
