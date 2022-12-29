using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainManager : MonoBehaviour
{
    public int wave;
    public int live;
    public int money;

    public int difficultModifer;

    public float baseRangeNormalTower;
    public int baseCostNormalTower;

    public float baseRangeFreezeTower;
    public int baseCostFreezeTower;

    public float baseRangeToxicTower;
    public int baseCostToxicTower;

    public int baseCostBombs;
    public float bombCooldown;

    public int costRemoveRockBig;
    public int costRemoveRocksmall;

    public GameObject cam;
    public GameObject musicPlayer;
    public GameObject spawnerObject;
    public GameObject startButton;
    public GameObject ghostTower;
    public GameObject ghostFreezeTower;
    public GameObject ghostToxicTower;
    public GameObject ghostBombs;
    public GameObject ui;

    public ParticleSystem explosion;

    //Encapsulation

    public bool win { get; private set; }
    private bool finalWave;
    public bool gameIsActive { get; private set; }

    [SerializeField]
    private bool waveRunning;
    private bool enemyOnField;
    public bool buildOn2xBase { get; set; }


    void Start()
    {
        spawnerObject.GetComponent<Spawner>();
        ui.GetComponent<UI>();
        gameIsActive = true;
    }

    void Update()
    {
        //Checks game states

        if (live <= 0 && gameIsActive)
        {
            gameIsActive = false;
            explosion.Play();
            musicPlayer.GetComponent<MusicPlayer>().PlayGameOverSound();
            Debug.Log("Gameover music");
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
                else if (finalWave && gameIsActive)
                {
                    gameIsActive = false;
                    win = true;
                    musicPlayer.GetComponent<MusicPlayer>().PlayWinMusic();
                    Debug.Log("Win music");
                }
            }
        }

    }

    public void GameStart()
    {
        
        cam.GetComponent<MoveCamera>().CamWelcomeToTopView();
        StartCoroutine(WaitUi());

    }

    //Abstraction

    public void StartWave()
    {
        if (gameIsActive)
        {
            musicPlayer.GetComponent<MusicPlayer>().PlayStartWaveSound();
            waveRunning = true;
            startButton.SetActive(false);
            wave++;
            ui.GetComponent<UI>().TextColorChange("Wave");

            if (wave == 10)
            {
                finalWave = true;
            }

            musicPlayer.GetComponent<MusicPlayer>().PlayMainMusic(wave);

            spawnerObject.GetComponent<Spawner>().SpawnWave(wave);
        }

    }

    //Abstraction

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

    //Abstraction

    public bool checkEnemysInGame()
    {

        bool enemysOnField = false;

        if (GameObject.Find("Enemy Normal(Clone)") == null && GameObject.Find("Enemy Fast(Clone)") == null && GameObject.Find("Enemy Spawnling(Clone)") == null && GameObject.Find("Enemy Boss(Clone)") == null && GameObject.Find("Enemy Elite(Clone)") == null && GameObject.Find("Enemy Boss Elite(Clone)") == null)
        {
            enemysOnField = false;
        }
        else
        {
            enemysOnField = true;
        }

        return enemysOnField;

    }

    IEnumerator WaitUi()
    {

        yield return new WaitForSeconds(5);
        ui.SetActive(true);

    }
}