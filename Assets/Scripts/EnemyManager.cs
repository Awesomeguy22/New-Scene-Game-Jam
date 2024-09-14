using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    //Spawns an enemy wave each time with a certain weight
    
    [SerializeField] GameManager gameManager;
    //Placeholder
    [SerializeField] GameObject[] spawnableEnemies;
    [SerializeField] int[] enemyWeights;

    //for each difficulty level, a list of enemy waves to spawn
    [SerializeField] int[][] possibleEnemyWaves;

    float timeBetweenWaves = 10;
    float timeTillNextWave;

    [SerializeField] int waveWeights;
    void Start()
    {
        
    }

    void Awake(){
        if (!gameManager){
            gameManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();

        }
        timeTillNextWave = timeBetweenWaves;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnWave() {
        timeTillNextWave = timeBetweenWaves;
        int randomStage = Random.Range(1,possibleEnemyWaves[gameManager.currentGameStage].Length);
        int[] wave = possibleEnemyWaves[randomStage];
        for (int i = 0; i < spawnableEnemies.Length; i++){
            int spawnCount = wave[i];

            //create a spawncount number of enemy i 
            for (int j = 0; j < spawnCount; j++) {
                //create enemy i 
                //Instantiate()
            }
        }
        //enemiesPerWave = {};
    }
}
