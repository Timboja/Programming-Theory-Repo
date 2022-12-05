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

    public float baseRangeFreezeTower;
    public int baseCostFreezeTower;

    public float baseRangeToxicTower;
    public int baseCostToxicTower;

    public int baseCostBombs;

    public int costRemoveRockBig;
    public int costRemoveRocksmall;

    public GameObject spawnerObject;
    public GameObject startButton;
    public GameObject ghostTower;
    public GameObject ghostFreezeTower;
    public GameObject ghostToxicTower;
    public GameObject ghostBombs;
    public GameObject ui;

    public ParticleSystem explosion;

    public bool win;
    private bool finalWave;
    public bool gameIsActive = true;
    public bool waveRunning;
    public bool enemyOnField;

    // Start is called before the first frame update
    void Start()
    {
        spawnerObject.GetComponent<Spawner>();
        ui.GetComponent<UI>();
    }

    // Update is called once per frame
    void Update()
    {
        //Checks game states

        if (live <= 0)
        {
            gameIsActive = false;
            explosion.Play();
        }

        if (waveRunning == true)
        {
            enemyOnField = checkEnemysInGame();

            if (!spawnerObject.GetComponent<Spawner>().enemysSpawing && !enemyOnField)
            {
                waveRunning = false;

                if (!finalWave)
                {
                    startButton.SetActive(true);
                }
                if (finalWave)
                {
                    gameIsActive = false;
                    win = true;
                }
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

            if (wave == 10)
            {
                finalWave = true;
            }

            spawnerObject.GetComponent<Spawner>().SpawnWave(wave);
        }

    }

    public void GhostTower()
    {
        if (gameIsActive)
        {
            if (ui.GetComponent<UI>().normalTowerClicked)
            {
                Instantiate(ghostTower, transform.position, transform.rotation);
            }
            else if (ui.GetComponent<UI>().freezeTowerClicked)
            {
                Instantiate(ghostFreezeTower, transform.position, transform.rotation);
            }
            else if (ui.GetComponent<UI>().toxicTowerClicked)
            {
                Instantiate(ghostToxicTower, transform.position, transform.rotation);
            }
            else if (ui.GetComponent<UI>().bombsClicked)
            {
                Instantiate(ghostBombs, transform.position, transform.rotation);
            }
        }

    }

    public bool checkEnemysInGame()
    {

        bool enemysOnField = false;

        if (GameObject.Find("Enemy Normal(Clone)") == null)
        {
            enemysOnField = false;
        }
        else
        {
            enemysOnField = true;
        }

        return enemysOnField;

    }

}