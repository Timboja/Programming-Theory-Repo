using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainManager : MonoBehaviour
{
    public int wave;
    public int live;
    public int money;

    public float baseRangeNormalTower;

    public int baseCostNormalTower;

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
        spawnerObject.GetComponent<Spawner>().SpawnWave();
    }

    public void BuildTower()
    {
        if (baseCostNormalTower <= money)
        {

            Instantiate(ghostTower, transform.position, transform.rotation);
        }

    }
}
