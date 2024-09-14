using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    GameManager gameManager;
    public float playerHealth;

    private float playerXP = 0;

    private bool showDebug = false;

    // Start is called before the first frame update
    void Start()
    {
        if (gameManager == null){
            gameManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DamagePlayer(float damage){
        playerHealth -= damage;

        if (showDebug) {
            Debug.Log($"Player taking Damage! Health is now {playerHealth}");
        }
    }

    public void GainXP(float xp) {
        playerXP += xp;
        gameManager.CheckGamePhase(playerXP);
    }



    void CheckDeath() {

        if (playerHealth < 0){
            gameManager.RestartGame();
        }
    }
}
