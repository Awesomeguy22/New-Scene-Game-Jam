using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
public class CutSceneManager : MonoBehaviour
{

    
    [SerializeField] Transform[] cutsceneFrames;
    [SerializeField] String mainSceneName;
    //[SerializeField] float[] cutsceneTimes;

    //[SerializeField] String mainSceneName;

    //start index is self
    int frameIndex = 1;
    //[SerializeField] float timeBetweenFrames = 5.0f;
    //[SerializeField] float timeSinceLastFrame = 0.0f;                                                                                                              


    private ControlsManager controlsManager;


    private void Awake() {
        this.controlsManager = FindObjectOfType<ControlsManager>();
    }

    private void OnEnable() {
        this.controlsManager.Continue += NextFrame;
        
    }

    private void OnDisable() {
        this.controlsManager.Continue -= NextFrame;
    }
    // Start is called before the first frame update
    void Start()
    {
        cutsceneFrames = transform.GetComponentsInChildren<Transform>();
        
        for (int i = 1; i < cutsceneFrames.Length; i++) {
            cutsceneFrames[i].gameObject.GetComponent<MeshRenderer>().enabled = false;
        }
        cutsceneFrames[1].gameObject.GetComponent<MeshRenderer>().enabled = true;

        //DontDestroyOnLoad(this);
    }


    void NextFrame(object sender,EventArgs e){
        frameIndex++;
        if (frameIndex == cutsceneFrames.Length){
            SceneManager.LoadScene(mainSceneName);
        } else{
            cutsceneFrames[frameIndex - 1].gameObject.GetComponent<MeshRenderer>().enabled = false;
            cutsceneFrames[frameIndex].gameObject.GetComponent<MeshRenderer>().enabled = true;
        }
    }

    // Update is called once per frame
    void Update()
    {

        /*
        timeSinceLastFrame += Time.deltaTime;
        if (timeSinceLastFrame >= timeBetweenFrames){
            timeSinceLastFrame = 0.0f;
            sceneIndex++;
            if (sceneIndex == cutsceneFrames.Length - 1){
                SceneManager.LoadScene(mainScene.name);
            } else {
                SceneManager.LoadScene(cutsceneFrames[sceneIndex].name);
            }
            
        }
        */
    }
}
