using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    //Spawns an enemy wave each time with a certain weight
    
    /*[SerializeField]*/ GameManager gameManager;

    GameObject player;
    [SerializeField] Transform enemies;
    //Placeholder
    [SerializeField] GameObject[] spawnableEnemies;
    [SerializeField] int[] enemyWeights;

    //for each difficulty level, a list of enemy waves to spawn
    //[SerializeField] int[][] possibleEnemyWaves;
    [SerializeField] GameObject[] wave1;

    [SerializeField] float spawnOffset;
    [SerializeField] float zOffset;
    [SerializeField] float timeBetweenWaves = 10;
    [SerializeField] float timeTillNextWave;

    [SerializeField] int waveWeights;
    void Start()
    {
        
    }

    void Awake(){
        if (!gameManager){
            gameManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();

        }
        if (!player){
            player = GameObject.FindGameObjectWithTag("Player");
        }
        if(!enemies){
            enemies = transform;
        }
        timeTillNextWave = timeBetweenWaves;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (timeTillNextWave <= 0) {
            SpawnWave();
            timeTillNextWave = timeBetweenWaves;

        }
        timeTillNextWave -= Time.deltaTime;
    }

    void SpawnWave() {
        //int randomStage = Random.Range(1,possibleEnemyWaves[gameManager.currentGameStage].Length);
        //int[] wave = possibleEnemyWaves[randomStage];
        /*
        for (int i = 0; i < spawnableEnemies.Length; i++){
            int spawnCount = wave[i];
            GameObject enemyToSpawn = spawnableEnemies[i];
            //create a spawncount number of enemy i 
            for (int j = 0; j < spawnCount; j++) {
                //create enemy i at spawnpos in global coords
                Vector2 spawnRand = Random.insideUnitCircle.normalized * spawnOffset;
                Vector3 spawnPos = player.transform.position + new Vector3(spawnRand.x, spawnRand.y, 0);
                Instantiate(enemyToSpawn, spawnPos, Quaternion.identity, transform);
                Debug.Log($"Spawning {enemyToSpawn.name} at position {spawnPos}");

            }
        }*/

        for (int i = 0; i < wave1.Length; i++) {
            GameObject enemyToSpawn = wave1[i];
            //create enemy i at spawnpos in global coords
            Vector2 spawnRand = Random.insideUnitCircle.normalized * spawnOffset;
            float spawnZOffset = Random.Range(-zOffset, zOffset);
            Vector3 spawnPos = player.transform.position + new Vector3(spawnRand.x, spawnRand.y, spawnZOffset);
            Instantiate(enemyToSpawn, spawnPos, Quaternion.identity, enemies);
            //Debug.Log($"Spawning {enemyToSpawn.name} at position {spawnPos}");
        }
        //enemiesPerWave = {};
    }
}
