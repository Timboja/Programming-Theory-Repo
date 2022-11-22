using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class UI : MonoBehaviour
{
    public GameObject mainManager;

    public TextMeshProUGUI moneyText;
    public TextMeshProUGUI waveText;
    public TextMeshProUGUI livesText;
    public TextMeshProUGUI wavesSurvivedText;

    public TextMeshProUGUI costNormalTowerText;
    public TextMeshProUGUI costFreezeTowerText;
    public TextMeshProUGUI costToxicTowerText;

    public int moneyUI;
    public int waveUI;
    public int livesUI;

    public int baseCostNormalTowerUi;
    public int baseCostFreezeTowerUi;
    public int baseCostToxicTowerUi;

    public bool normalTowerClicked = false;
    public bool freezeTowerClicked = false;
    public bool toxicTowerClicked = false;

    // Start is called before the first frame update
    void Start()
    {
        mainManager.GetComponent<MainManager>();

        baseCostNormalTowerUi = mainManager.GetComponent<MainManager>().baseCostNormalTower;
        costNormalTowerText.text = "Cost: " + baseCostNormalTowerUi;

        baseCostFreezeTowerUi = mainManager.GetComponent<MainManager>().baseCostFreezeTower;
        costFreezeTowerText.text = "Cost: " + baseCostFreezeTowerUi;

        baseCostToxicTowerUi = mainManager.GetComponent<MainManager>().baseCostToxicTower;
        costToxicTowerText.text = "Cost: " + baseCostToxicTowerUi;
    }

    // Update is called once per frame
    void Update()
    {
        //Win and loose context

        if (mainManager.GetComponent<MainManager>().gameIsActive == false && !mainManager.GetComponent<MainManager>().win)
        {
            transform.Find("Game Over Context").gameObject.SetActive(true);
        }
        if (mainManager.GetComponent<MainManager>().win)
        {
            transform.Find("Win Context").gameObject.SetActive(true);
        }

        moneyUI = mainManager.GetComponent<MainManager>().money;
        moneyText.text = "Money: " + moneyUI;

        waveUI = mainManager.GetComponent<MainManager>().wave;
        waveText.text = "Wave: " + waveUI;

        livesUI = mainManager.GetComponent<MainManager>().live;
        livesText.text = "Lives: " + livesUI;

        waveUI = mainManager.GetComponent<MainManager>().wave;
        wavesSurvivedText.text = "Waves survived: " + (waveUI - 1);
    }

    public void StartWaveClicked()
    {
        mainManager.GetComponent<MainManager>().StartWave();
    }

    //When the Tower Image is clicked

    public void TowerNormalClicked()
    {
        if (!normalTowerClicked)
        {
            normalTowerClicked = true;
            freezeTowerClicked = false;
            toxicTowerClicked = false;

            mainManager.GetComponent<MainManager>().GhostTower();
        }
    }

    public void TowerFreezeClicked()
    {
        if (!freezeTowerClicked)
        {
            freezeTowerClicked = true;
            normalTowerClicked = false;
            toxicTowerClicked = false;

            mainManager.GetComponent<MainManager>().GhostTower();
        }
    }

    public void TowerToxicClicked()
    {
        if (!toxicTowerClicked)
        {
            toxicTowerClicked = true;
            normalTowerClicked = false;
            freezeTowerClicked = false;

            mainManager.GetComponent<MainManager>().GhostTower();
        }
    }

    public void tryAgainClicked()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

}
