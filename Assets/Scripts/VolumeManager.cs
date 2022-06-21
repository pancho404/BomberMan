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
        slider.value = PlayerPrefs.GetFloat("volume");
        audioSource.volume = slider.value;
    }

    public void ChangeVolume(float volume)
    {
        PlayerPrefs.SetFloat("volume", volume);
    }
}
