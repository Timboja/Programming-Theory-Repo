using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainManager : MonoBehaviour
{
    public int wave;
    public int live;
    public int money;

    public int difficultModifer;
    public int startEnemys;

    public float baseRangeNormalTower;
    public int baseCostNormalTower;

    public int normalEnemysToSpawn;

    public GameObject spawnerObject;
    public GameObject startButton;
    public GameObject ghostTower;

    public bool gameIsActive = true;
    public bool waveRunning;
    public bool enemyOnField;

    // Start is called before the first frame update
    void Start()
    {
        spawnerObject.GetComponent<Spawner>();
    }

    // Update is called once per frame
    void Update()
    {
        if (live <= 0)
        {
            gameIsActive = false;
        }

        if (waveRunning == true)
        {
            enemyOnField = checkEnemysInGame();

            if (!spawnerObject.GetComponent<Spawner>().enemysSpawing && !enemyOnField)
            {
                waveRunning = false;
                startButton.SetActive(true);
            }
        }

    }

    public void StartWave()
    {
        if (gameIsActive)
        {
            waveRunning = true;
            startButton.SetActive(false);
            wave++;

            normalEnemysToSpawn = Mathf.RoundToInt(((normalEnemysToSpawn + startEnemys) * wave) / 2 + difficultModifer);
            Debug.Log("normalEnemysToSpawn: " + normalEnemysToSpawn);

            spawnerObject.GetComponent<Spawner>().SpawnWave(normalEnemysToSpawn);
        }

    }

    public void GhostTower()
    {
        if (gameIsActive)
        {
            Instantiate(ghostTower, transform.position, transform.rotation);
        }

    }

    public bool checkEnemysInGame()
    {

        bool enemysOnField = false;

        if (GameObject.Find("Enemy Normal(Clone)") == null)
        {
            Debug.Log("No enemy on field");
            enemysOnField = false;
        }
        else
        {
            Debug.Log("Enemy on field");
            enemysOnField = true;
        }

        return enemysOnField;

    }


}
