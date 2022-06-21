using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeManager : MonoBehaviour
{
    [SerializeField] AudioSource audioSource;
    [SerializeField] Slider slider;

    // Update is called once per frame
    void Update()
    {
        PlayerPrefs.SetFloat("volume", slider.value);
        slider.value = PlayerPrefs.GetFloat("volume");
        audioSource.volume = slider.value;
       
    }
}
