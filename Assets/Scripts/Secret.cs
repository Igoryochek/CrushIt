using UnityEngine;

public class Secret : MonoBehaviour
{
    [SerializeField] private SecretSwitch _secretSwitch;
    [SerializeField] private HintPanel _hintPanel;
    [SerializeField] private AudioSource _audioSource;

    private void OnEnable()
    {
        _secretSwitch.TurnedOn += OnTurnedOn;
    }

    private void OnDisable()
    {
        _secretSwitch.TurnedOn -= OnTurnedOn;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (gameObject.TryGetComponent(out Secret secret) && collision.gameObject.TryGetComponent(out Player player))
        {
            _hintPanel.gameObject.SetActive(true);
            _audioSource.Play();
        }
    }

    private void OnTurnedOn()
    {
        gameObject.SetActive(false);
    }
}
