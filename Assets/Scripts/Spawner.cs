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
   public void Start()
    {
        //Array Init

        enemyWaves = new int[,] {

        // {  Boss Enemy, Elite Enemy, Spawnling Enemy, Normal Enemy, Fast Enemy, Elite Boss Enemy }

        // Wave1
        { 0, 0, 0, 3, 0, 0 },
        // Wave2
        { 0, 0, 0, 15, 0, 0 },
        // Wave3
        { 0, 0, 1, 2, 0, 0 },
        // Wave4
        { 0, 0, 2, 30, 15, 0 },
        // Wave5
        { 1, 0, 0, 4, 0, 0 },
        // Wave6
        { 0, 2, 2, 30, 4, 0 },
        // Wave7
        { 0, 10, 8, 0, 30, 0 },
        // Wave8
        { 0, 25, 4, 30, 50, 0 },
        // Wave9
        { 0, 12, 4, 40, 60, 0 },
        // Wave10
        { 4, 20, 8, 40, 60, 1 },

    };

        mainManager.GetComponent<MainManager>();
    }

    public void SpawnWave(int wave)
    {

        StartCoroutine(SpawnWaveDelay(wave));

        spawnDelay -= 0.05F;

        if (wave >= 7)
        {
            spawnDelay -= 0.05F;
        }

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