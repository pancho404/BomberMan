using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeManage : MonoBehaviour
{
    [SerializeField] private Slider volumeSlide;

    private float volume;

    // Update is called once per frame
    public void ChangeVolume(float volume)
    {
        this.volume = volume;

        PlayerPrefs.SetFloat("Vol", volume);
    }
}
