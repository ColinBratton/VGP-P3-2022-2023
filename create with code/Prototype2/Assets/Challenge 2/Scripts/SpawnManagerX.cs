using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManagerX : MonoBehaviour
{
    public GameObject[] ballPrefabs;
    public int ballIndex;
    private float spawnLimitXLeft = -20;
    private float spawnLimitXRight = 0;
    private float spawnPosY = 30;

    private float startDelay = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnRandomBall", startDelay);
    }

    // Spawn random ball at random x position at top of play area
    void SpawnRandomBall ()
    {
        // Generate random ball index and random spawn position
       int ballIndex = Random.Range(0, ballPrefabs.Length);
        Vector3 spawnPos = new Vector3(Random.Range(spawnLimitXLeft, spawnLimitXRight), 0, spawnPosY, 0);

        // instantiate ball at random spawn location
        Instantiate(ballPrefabs[animalIndex], spawnPos, ballPrefabs[ballIndex].transform.rotation);
    }

}
