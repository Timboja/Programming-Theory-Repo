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

        // { Normal Enemy, Fast Enemy, Spawnling Enemy, Boss Enemy }

        // Wave1
        { 3, 0, 0, 0 },
        // Wave2
        { 10, 0, 0, 0 },
        // Wave3
        { 2, 6, 0, 0 },
        // Wave4
        { 20, 8, 2, 0 },
        // Wave5
        { 2, 0, 0, 1 },
        // Wave6
        { 30, 4, 2, 0 },
        // Wave7
        { 0, 0, 8, 0 },
        // Wave8
        { 20, 0, 0, 2 },
        // Wave9
        { 0, 30, 1, 0 },
        // Wave10
        { 50, 40, 4, 4 },

    };

        mainManager.GetComponent<MainManager>();
    }

    public void SpawnWave(int wave)
    {

        StartCoroutine(SpawnWaveDelay(wave));

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