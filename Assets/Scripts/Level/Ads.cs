using System;
using UnityEngine;
using YG;

namespace Level
{
    public class Ads : MonoBehaviour
    {
        private const int Id = 0;

        public event Action StartAdsShowing;

        public void ShowInterstitialAd()
        {
            YandexGame.RewVideoShow(Id);
            StartAdsShowing?.Invoke();
        }
    }
}
