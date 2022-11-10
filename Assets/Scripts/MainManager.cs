using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainManager : MonoBehaviour
{
    public int wave;
    public int live;
    public int money;

    public int difficultModifer;
    public bool waveRunning;
    public int startEnemys;

    public float baseRangeNormalTower;
    public int baseCostNormalTower;

    public int normalEnemysToSpawn;

    public GameObject spawnerObject;

    public GameObject ghostTower;


    // Start is called before the first frame update
    void Start()
    {
        spawnerObject.GetComponent<Spawner>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void StartWave()
    {
        waveRunning = true;
        wave++;

        normalEnemysToSpawn = Mathf.RoundToInt(((normalEnemysToSpawn + startEnemys)* wave) / 2 + difficultModifer);
        Debug.Log("normalEnemysToSpawn: " + normalEnemysToSpawn);

        spawnerObject.GetComponent<Spawner>().SpawnWave(normalEnemysToSpawn);
    }

    public void GhostTower()
    {

        Instantiate(ghostTower, transform.position, transform.rotation);

    }

}
