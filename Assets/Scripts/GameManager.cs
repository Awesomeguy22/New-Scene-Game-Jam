using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    public int playerHealth;

    private int playerXP = 0;
    [SerializeField] int[] ExpThresholds = {};
    
    //int from 1-4 representing the phase of the game
    //Used by spawner and attack logic
    public int currentGameStage = 1;

    [SerializeField] int winStage = 5;
    [SerializeField] Scene winScreen;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }


    void CheckGamePhase() {
        if (playerXP > ExpThresholds[currentGameStage - 1]) {
            currentGameStage += 1;
        }

        if (currentGameStage == winStage){
            Win();
        }
    }

    void CheckDeath() {

        if (playerHealth < 0){
            RestartGame();
        }
    }

    void RestartGame() {
        Debug.Log("You Lost");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void Win(){
        SceneManager.LoadScene(winScreen.name);
    }
    void DamagePlayer(int damage){
        playerHealth -= damage;

    }

    void GainXP(int xp) {
        playerXP += xp;
        CheckGamePhase();
    }
}
