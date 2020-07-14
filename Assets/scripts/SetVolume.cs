using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetVolume : MonoBehaviour
{
    void Start()
    {
        GetComponent<Slider>().value = AudioListener.volume;
    }

    public void SetVol(float vol) {
        AudioListener.volume = vol;
    }
}
