using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update

    
    //int from 1-4 representing the phase of the game
    //Used by spawner and attack logic
    public int currentGameStage = 1;

    [SerializeField] int winStage = 5;
    [SerializeField] Scene winScreen;

    [SerializeField] int[] ExpThresholds = {};


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }


    public void CheckGamePhase(float playerXP) {
        if (playerXP > ExpThresholds[currentGameStage - 1]) {
            currentGameStage += 1;
        }

        if (currentGameStage == winStage){
            Win();
        }
    }


    public void RestartGame() {
        Debug.Log("You Lost, Restarting Current Scene");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Win(){
        SceneManager.LoadScene(winScreen.name);
    }

}
