using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound : MonoBehaviour
{
    public void TurnOnSound()
    {
        AudioListener.volume = 1;
    }
    
    public void TurnOffSound()
    {
        AudioListener.volume = 0;

    }
}
