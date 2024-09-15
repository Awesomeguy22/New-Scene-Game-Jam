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
    [SerializeField]
    private Slider effectsVolume;

    private AudioManager audioManager;
    
    private void Awake() {
        this.audioManager = FindObjectOfType<AudioManager>();

        this.masterVolume.value = this.audioManager.GetVolume(AudioManager.VolumeType.master);
        this.masterVolume.onValueChanged.AddListener((float value) => { ChangeMasterVolume(value, AudioManager.VolumeType.master); });

        this.bgmVolume.value = this.audioManager.GetVolume(AudioManager.VolumeType.bgm);
        this.bgmVolume.onValueChanged.AddListener((float value) => { ChangeMasterVolume(value, AudioManager.VolumeType.bgm); });

        this.effectsVolume.value = this.audioManager.GetVolume(AudioManager.VolumeType.effect);
        this.effectsVolume.onValueChanged.AddListener((float value) => { ChangeMasterVolume(value, AudioManager.VolumeType.effect); });
    }

    public void ChangeMasterVolume(float value, AudioManager.VolumeType volumeType) {
        this.audioManager.ChangeVolume(value, volumeType);
    }

}