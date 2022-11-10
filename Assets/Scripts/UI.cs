using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UI : MonoBehaviour
{
    public GameObject mainManager;

    public TextMeshProUGUI moneyText;
    public TextMeshProUGUI waveText;
    public TextMeshProUGUI livesText;

    public int moneyUI;
    public int waveUI;
    public int livesUI;

    public bool normalTowerClicked = false;

    // Start is called before the first frame update
    void Start()
    {
        mainManager.GetComponent<MainManager>();
    }

    // Update is called once per frame
    void Update()
    {
        moneyUI = mainManager.GetComponent<MainManager>().money;
        moneyText.text = "Money: " + moneyUI;

        waveUI = mainManager.GetComponent<MainManager>().wave;
        waveText.text = "Wave: " + waveUI;

        livesUI = mainManager.GetComponent<MainManager>().live;
        livesText.text = "Lives: " + livesUI;

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

}
