using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
public class CutSceneManager : MonoBehaviour
{
    [SerializeField] UnityEngine.SceneManagement.Scene[] cutsceneFrames;

    [SerializeField] UnityEngine.SceneManagement.Scene mainScene;
    int sceneIndex = 0;
    [SerializeField] float timeBetweenFrames = 5.0f;
    [SerializeField] float timeSinceLastFrame = 0.0f;                                                                                                              

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this);
    }

    // Update is called once per frame
    void Update()
    {

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
    }
}
