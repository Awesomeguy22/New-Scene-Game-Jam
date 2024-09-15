using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneSwitcher : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] String nextSceneName;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("Space Bar") || Input.GetMouseButtonDown(0)){
            SceneManager.LoadScene(nextSceneName);
        }
    }
}
