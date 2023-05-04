using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] enemies;
    public GameObject powerup;

    private float zEnemySpawn = 12.0f;
    private Vector3 spawnPos = new Vector3(25, 0, 210);
    private float xSpawnRange = 16.0f;
    private float zPowerupRange = 5.0f;
    private float ySpawn = .75f;
    private float ySpawnE = 1.5f;
    public GameObject Floor;

    private float powerupSpawnTime = 5.0f;
    private float enemySpawnTime = 1.0f;
    private float startDelay = 1.0f;
    private float FloorZ;
    private float FloorSpawn;
    private bool gameOver;
    // Start is called before the first frame update
    void Start()
    {
       InvokeRepeating("SpawnRandomEnemy", startDelay, enemySpawnTime);
       InvokeRepeating("SpawnPowerup", startDelay, powerupSpawnTime);
       //InvokeRepeating("SpawnFloor", startDelay, FloorSpawn);
       gameOver = true;
       StartCoroutine(SpawnFloor());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnRandomEnemy()
    {
        float randomX = Random.Range(-xSpawnRange, xSpawnRange);
        int randomIndex = Random.Range(0, enemies.Length);

        Vector3 spawnPos = new Vector3(randomX, ySpawnE, zEnemySpawn);

        Instantiate(enemies[randomIndex], spawnPos, enemies[randomIndex]. gameObject.transform.rotation);
    }
    void SpawnPowerup()
    {
        float randomX = Random.Range(-xSpawnRange, xSpawnRange);
        float randomZ = Random.Range (-zPowerupRange, zPowerupRange);

        Vector3 spawnPos = new Vector3(randomX, ySpawn, randomZ);

        Instantiate(powerup, spawnPos, powerup.gameObject.transform.rotation);
    }
    IEnumerator SpawnFloor()
    {
        while(gameOver)
        {
            Instantiate(Floor, spawnPos, Floor.transform.rotation);
        }
    }
   /* void SpawnFloor()
    {
        FloorZ = Floor.transform.position.z;
         if(FloorZ < 100)
         {
         Debug.Log("spawn");
         Instantiate(Floor, spawnPos, Floor.transform.rotation);
    }
}*/
}