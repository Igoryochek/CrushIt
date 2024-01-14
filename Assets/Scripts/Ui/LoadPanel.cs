using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class LoadPanel : MonoBehaviour
    {
        [SerializeField] private Slider _slider;
        [SerializeField] private float _loadSpeed;

        private void Start()
        {
            StartCoroutine(Loading());
        }

        private IEnumerator Loading()
        {
            while (_slider.value != _slider.maxValue)
            {
                _slider.value = Mathf.MoveTowards(_slider.value, _slider.maxValue, _loadSpeed * Time.deltaTime);
                yield return null;
            }

            gameObject.SetActive(false);
        }
    }
}

