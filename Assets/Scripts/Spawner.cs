using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject mainManager;
    public GameObject enemy;

    public float spawnDelay;
    public bool enemysSpawing;

    // Start is called before the first frame update
    void Start()
    {
        mainManager.GetComponent<MainManager>();
    }

    public void SpawnWave(int normalEnemysToSpawn)
    {

        StartCoroutine(SpawnWaveDelay(normalEnemysToSpawn));

    }


    public IEnumerator SpawnWaveDelay(int normalEnemysToSpawn)
    {
        enemysSpawing = true;

        for (int i = 0; i < normalEnemysToSpawn; i++)
        {
            yield return new WaitForSeconds(spawnDelay);
            Instantiate(enemy, transform.position, transform.rotation);
        }

        enemysSpawing = false;
    }
}
