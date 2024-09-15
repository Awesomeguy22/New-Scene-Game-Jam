using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioSettings : MonoBehaviour
{

    [SerializeField]
    private Slider masterVolume;
    [SerializeField]
    private Slider bgmVolume;

    private AudioManager audioManager;
    
    private void Awake() {
        this.audioManager = FindObjectOfType<AudioManager>();

        this.masterVolume.value = this.audioManager.GetVolume();
        this.masterVolume.onValueChanged.AddListener((float value) => { ChangeMasterVolume(value); });
    }

    public void ChangeMasterVolume(float value) {
        this.audioManager.ChangeVolume(value);
    }

}