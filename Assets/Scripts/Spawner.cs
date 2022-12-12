using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject mainManager;

    public GameObject[] enemySpawnList;

    public float spawnDelay;
    public bool enemysSpawing;

    public int[,] enemyWaves;

    // Start is called before the first frame update
    void Start()
    {
        //Array Init

        enemyWaves = new int[,] {

        // { Boss Enemy, Fast Enemy, Spawnling Enemy, Normal Enemy }

        // Wave1
        { 0, 0, 0, 3 },
        // Wave2
        { 0, 0, 0, 12 },
        // Wave3
        { 0, 10, 1, 0 },
        // Wave4
        { 0, 15, 2, 20 },
        // Wave5
        { 1, 10, 0, 10 },
        // Wave6
        { 0, 4, 2, 30 },
        // Wave7
        { 0, 0, 10, 0 },
        // Wave8
        { 0, 30, 0, 30 },
        // Wave9
        { 0, 30, 4, 0 },
        // Wave10
        { 3, 20, 8, 40 },

    };

        mainManager.GetComponent<MainManager>();
    }

    public void SpawnWave(int wave)
    {

        StartCoroutine(SpawnWaveDelay(wave));
        spawnDelay -= 0.05F;

    }


    public IEnumerator SpawnWaveDelay(int wave)
    {
        enemysSpawing = true;

        for (int i = 0; i < enemySpawnList.Length; i++)
        {
            for (int j = 0; j < enemyWaves[wave - 1,i]; j++)
            {
                yield return new WaitForSeconds(spawnDelay);
                Instantiate(enemySpawnList[i], transform.position, transform.rotation);
            }
        }

        enemysSpawing = false;
    }
}