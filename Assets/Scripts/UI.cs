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
    public TextMeshProUGUI costNormalTowerText;
    public TextMeshProUGUI wavesSurvivedText;

    public int moneyUI;
    public int waveUI;
    public int livesUI;

    public int baseCostNormalTowerUi;

    public bool normalTowerClicked = false;

    // Start is called before the first frame update
    void Start()
    {
        mainManager.GetComponent<MainManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (mainManager.GetComponent<MainManager>().gameIsActive == false)
        {
            transform.Find("Game Over Context").gameObject.SetActive(true);
        }

        moneyUI = mainManager.GetComponent<MainManager>().money;
        moneyText.text = "Money: " + moneyUI;

        waveUI = mainManager.GetComponent<MainManager>().wave;
        waveText.text = "Wave: " + waveUI;

        livesUI = mainManager.GetComponent<MainManager>().live;
        livesText.text = "Lives: " + livesUI;

        baseCostNormalTowerUi = mainManager.GetComponent<MainManager>().baseCostNormalTower;
        costNormalTowerText.text = "Cost: " + baseCostNormalTowerUi;

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
           // Debug.Log("Tower Clicked!");

            normalTowerClicked = true;

            mainManager.GetComponent<MainManager>().GhostTower();
        }

    }

    public void tryAgainClicked()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

}
