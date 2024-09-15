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
    //[SerializeField] GameObject[] spawnableEnemies;
    //[SerializeField] int[] enemyWeights;

    //for each difficulty level, a list of enemy waves to spawn
    //[SerializeField] int[][] possibleEnemyWaves;
    [SerializeField] GameObject[] wave1;
    
    [SerializeField] GameObject[] wave2;
    [SerializeField] GameObject[] wave3;

    [SerializeField] float spawnOffsetDistance;
    [SerializeField] float zOffsetDistance;
    [SerializeField] float timeBetweenWaves = 10;
    [SerializeField] float timeTillNextWave;

    [SerializeField] int waveWeights;

    private bool showDebug = false;

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
        timeTillNextWave = 0;
    }

    public void Reset() {
        for (int i = 0; i < enemies.childCount; i++) {
            Destroy(enemies.GetChild(i).gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
        if (timeTillNextWave <= 0) {
            switch (gameManager.currentGameStage) {
                case 1:
                    SpawnWave(wave1);
                    break;
                case 2:
                    SpawnWave(wave2);
                    break;
                case 3:
                    SpawnWave(wave3);
                    break;

            }
            timeTillNextWave = timeBetweenWaves + Random.Range(0,1.0f);

        }
        timeTillNextWave -= Time.deltaTime;
    }

    void SpawnWave(GameObject[] wave) {
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
        for (int i = 0; i < wave.Length; i++) {

            GameObject enemyToSpawn = wave[i];
            //create enemy i at spawnpos in global coords
            Vector2 spawnRand = Random.insideUnitCircle.normalized * spawnOffsetDistance;
            float spawnZOffset = Random.Range(-zOffsetDistance, 0);
            Vector3 spawnPos = player.transform.position + new Vector3(spawnRand.x, spawnRand.y, spawnZOffset);
            Instantiate(enemyToSpawn, spawnPos, Quaternion.identity, enemies);

            if (showDebug) {
                Debug.Log($"Spawning {enemyToSpawn.name} at position {spawnPos}");
            }
        }
        //enemiesPerWave = {};
    }
}
