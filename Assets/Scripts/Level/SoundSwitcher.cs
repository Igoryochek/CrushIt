using UnityEngine;

namespace Level
{
    public class SoundSwitcher : MonoBehaviour
    {
        private const float FullSoundValue = 1f;
        private const float ZeroSoundValue = 0f;

        public void TurnOnSound()
        {
            AudioListener.volume = FullSoundValue;
        }

        public void TurnOffSound()
        {
            AudioListener.volume = ZeroSoundValue;
        }
    }
}