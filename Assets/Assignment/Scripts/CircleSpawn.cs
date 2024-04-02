using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleSpawn : MonoBehaviour
{
    public GameObject[] circlePrefab;
    //public GameObject circlePinkPrefab;
    //public GameObject circleYellowPrefab;
    //public GameObject circleWhitePrefab;

    //to use space key to spawn prefabs 
    public KeyCode spawnKey = KeyCode.Space; 

    //to use to stop spawning the prefabs
    private bool isSpawning = false;

    //spawn circles for two seconds if spacekey is pressed
    private float timer = 0f;
    private float spawnDuration = 2f;

    //limiting the number of prefabs spawned by 15 
    private int prefabsSpawned = 0;
    private int maxPrefabs = 15;

    void Update()
    {
  
        if (Input.GetKeyDown(spawnKey) && !isSpawning)
        {
            isSpawning = true;
            timer = 0f;
            prefabsSpawned = 0;
        }

        if (isSpawning)
        {
            timer += Time.deltaTime;

            //if 2 seconds passed or if 15 prefabs has been spawned, stop 
            if (timer >= spawnDuration || prefabsSpawned >= maxPrefabs)
            {
                isSpawning = false; 
                return; 
            }

            //the range of where the prefabs spawn
            Vector2 randomSpawnPosition = new Vector2(Random.Range(-15f, 15f), Random.Range(-15f, 15f));

            //instantiates only the white circle prefab 
            Instantiate(circlePrefab[Random.Range (0,4)], randomSpawnPosition, Quaternion.identity);

            prefabsSpawned++;
        }
    }
}
