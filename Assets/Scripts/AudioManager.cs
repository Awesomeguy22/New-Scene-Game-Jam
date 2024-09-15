using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField]
    private AudioClip[] audioFiles;
    [SerializeField]
    [Range(0, 1)]
    private float masterVolume = 1;
    [SerializeField]
    [Range(0, 1)]
    private float bgmVolume = 1;
    [SerializeField]
    [Range(0, 1)]
    private float effectsVolume = 1;

    private AudioSource[] audioSources = new AudioSource[2];

    public enum VolumeType {
        master, 
        bgm,
        effect,
    }

    // enter audio clip name to use when calling clip, order has to be the same as the order in audioFiles
    public enum ClipName {
        bgm,
        intro,
        projectileHit,

        chainBreak,
    }

    private void Awake() {
        DontDestroyOnLoad(gameObject);
        this.audioSources = FindObjectsByType<AudioSource>(FindObjectsSortMode.None);
        this.audioSources[0].volume = masterVolume * bgmVolume;
    }

    private void Start() {
        PlayBGM(ClipName.intro);
    }
    
    public void PlayAudioClip(ClipName clip) {
        this.audioSources[1].PlayOneShot(audioFiles[(int)clip]); 
    }

    public void PlayBGM(ClipName clip) {
        this.audioSources[0].clip = audioFiles[(int)clip];
        this.audioSources[0].loop = true;
        this.audioSources[0].Play();
        
    }

    public void ChangeVolume(float volume, VolumeType volumeType) {
        if (volume > 1) {
            return;
        }


        switch (volumeType) {
            case VolumeType.master:
                this.masterVolume = volume;
                break;

            case VolumeType.bgm:
                this.bgmVolume = volume;
                break;

            case VolumeType.effect:
                this.effectsVolume = volume;
                break;
            default: break;
        }
        this.audioSources[0].volume = masterVolume * bgmVolume;
        this.audioSources[1].volume = masterVolume * effectsVolume;
    }

    public float GetVolume(VolumeType volumeType) {
        switch (volumeType) {
            case VolumeType.master: return this.masterVolume; 
            case VolumeType.bgm: return this.bgmVolume;
            case VolumeType.effect: return this.effectsVolume;
            default: return 0;
        }
    }
}