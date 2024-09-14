using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField]
    private AudioClip[] audioFiles;

    private AudioSource audioSource;

    // enter audio clip name to use when calling clip, order has to be the same as the order in audioFiles
    public enum ClipName {
        bgm,
    }

    private void Awake() {
        DontDestroyOnLoad(gameObject);
        this.audioSource = FindObjectOfType<AudioSource>();
    }

    private void Start() {
        PlayBGM(ClipName.bgm);
    }
    
    public void PlayAudioClip(ClipName clip) {
        this.audioSource.PlayOneShot(audioFiles[(int)clip]); 
    }

    public void PlayBGM(ClipName clip) {
        this.audioSource.clip = audioFiles[(int)clip];
        this.audioSource.loop = true;
        this.audioSource.Play();
        
    }
}