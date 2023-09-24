using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcSpawner : MonoBehaviour
{
    public GameObject[] NpcPrefabs;
    public Path[] spawnPoints;

    int currSpawned = 0;
    System.Random random;
    bool coroutineRunning = false;

    private void Start()
    {
        random = new System.Random();
    }
    void Update()
    {
        //wait for prev coroutine to finish before starting another
        if(!coroutineRunning)
        {
            coroutineRunning= true;
            StartCoroutine(SpawnResidents());
        }
    }
    IEnumerator SpawnResidents()
    {
        bool spawned = false;
        //random time between each spawn
        float spawnInterval = Random.Range(2, 5);
        yield return new WaitForSeconds(spawnInterval);
        
        while (!spawned && currSpawned < 20)
        {
            spawned = true;
            //randomize model
            int residentIndex = random.Next(0, NpcPrefabs.Length);
            Debug.Log(residentIndex);
            //randomize spawn location
            int spawnPoint =random.Next(0, spawnPoints.Length);

            Path chosenPath = spawnPoints[spawnPoint];
            //spawn
            GameObject npcObj = Instantiate(NpcPrefabs[residentIndex], chosenPath.transform.position, Quaternion.identity);

            //set path
            npcObj.GetComponent<NpcChapter1>().SetPath(chosenPath);
            currSpawned++;
            
        }
        coroutineRunning= false;
    }
}
