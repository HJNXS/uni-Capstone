using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class SettingScript : MonoBehaviour {

    public AudioMixer audioMixer;

    public void SetVolume(Slider slider)
    {
        audioMixer.SetFloat(slider.name, slider.value); //Note: Slider name should be same in audio mixer and scene
    }
}
