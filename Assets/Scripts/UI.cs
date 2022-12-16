using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    public GameObject mainManager;

    public TextMeshProUGUI moneyText;
    public TextMeshProUGUI waveText;
    public TextMeshProUGUI livesText;
    public TextMeshProUGUI wavesSurvivedText;
    public TextMeshProUGUI notEnoughMoneyText;

    public TextMeshProUGUI costNormalTowerText;
    public TextMeshProUGUI costFreezeTowerText;
    public TextMeshProUGUI costToxicTowerText;
    public TextMeshProUGUI costBombsText;

    public GameObject infoText;
    public bool noteEnoughMoney;

    public int moneyUI;
    public int waveUI;
    public int livesUI;

    public int baseCostNormalTowerUi;
    public int baseCostFreezeTowerUi;
    public int baseCostToxicTowerUi;
    public int baseCostBombsUi;

    public bool normalTowerClicked = false;
    public bool freezeTowerClicked = false;
    public bool toxicTowerClicked = false;
    public bool bombsClicked = false;
    public bool killGhost;

    public GameObject moveCamScript;

    private float infoDelay = 2F;
    public bool waitCoRunning;

    public Button bombButton;

    private float colorMoneyChangeTime = 0;
    private float colorWaveChangeTime = 0;
    private float colorLivesChangeTime = 0;

    private bool moneyLerpColorText;
    private bool waveLerpColorText;
    private bool livesLerpColorText;

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

        baseCostBombsUi = mainManager.GetComponent<MainManager>().baseCostBombs;
        costBombsText.text = "Cost: " + baseCostBombsUi;
    }

    // Update is called once per frame
    void Update()
    {

        if (moneyLerpColorText == true)
        {
            moneyText.color = Color.Lerp(Color.yellow, Color.white, colorMoneyChangeTime);
            colorMoneyChangeTime += 0.05F;

            if (colorMoneyChangeTime >= 1)
            {
                colorMoneyChangeTime = 0;
                moneyLerpColorText = false;
            }
        }
        if (waveLerpColorText == true)
        {
            waveText.color = Color.Lerp(Color.blue, Color.white, colorWaveChangeTime);
            colorWaveChangeTime += 0.05F;

            if (colorWaveChangeTime >= 1)
            {
                colorWaveChangeTime = 0;
                waveLerpColorText = false;
            }
        }
        if (livesLerpColorText == true)
        {
            livesText.color = Color.Lerp(Color.red, Color.white, colorLivesChangeTime);
            colorLivesChangeTime += 0.05F;

            if (colorLivesChangeTime >= 1)
            {
                colorLivesChangeTime = 0;
                livesLerpColorText = false;
            }
        }


        //Win and loose context

        if (mainManager.GetComponent<MainManager>().gameIsActive == false && !mainManager.GetComponent<MainManager>().win)
        {
            transform.Find("Game Over Context").gameObject.SetActive(true);
            StartCoroutine(Wait());
        }

        if (mainManager.GetComponent<MainManager>().win)
        {
            transform.Find("Win Context").gameObject.SetActive(true);
            StartCoroutine(Wait());
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

        if (mainManager.GetComponent<MainManager>().wave  == 5)
        {
            transform.Find("Boss Wave").gameObject.SetActive(true);
            StartCoroutine(WaveInfoDelay());
        }

        if (mainManager.GetComponent<MainManager>().wave == 10)
        {
            transform.Find("Final Wave").gameObject.SetActive(true);
            StartCoroutine(WaveInfoDelay());
        }
    }

    //When the Tower Image is clicked

    public void TowerNormalClicked()
    {

        //Prevents spawning multiple ghost towers

        if (freezeTowerClicked || toxicTowerClicked || bombsClicked)
        {
            killGhost = true;
        }

        if (!normalTowerClicked)
        {
            normalTowerClicked = true;
            freezeTowerClicked = false;
            toxicTowerClicked = false;
            bombsClicked = false;

            mainManager.GetComponent<MainManager>().GhostTower();

        }
    }

    public void TowerFreezeClicked()
    {
        if (normalTowerClicked || toxicTowerClicked || bombsClicked)
        {
            killGhost = true;
        }

        if (!freezeTowerClicked)
        {
            freezeTowerClicked = true;
            normalTowerClicked = false;
            toxicTowerClicked = false;
            bombsClicked = false;

            mainManager.GetComponent<MainManager>().GhostTower();
        }
    }

    public void TowerToxicClicked()
    {

        if (normalTowerClicked || freezeTowerClicked || bombsClicked)
        {
            killGhost = true;
        }

        if (!toxicTowerClicked)
        {
            toxicTowerClicked = true;
            normalTowerClicked = false;
            freezeTowerClicked = false;
            bombsClicked = false;

            mainManager.GetComponent<MainManager>().GhostTower();
        }
    }

    public void BombsClicked()
    {

        if (normalTowerClicked || freezeTowerClicked || toxicTowerClicked)
        {
            killGhost = true;
        }

        if (!bombsClicked)
        {
            bombsClicked = true;
            normalTowerClicked = false;
            freezeTowerClicked = false;
            toxicTowerClicked = false;

            mainManager.GetComponent<MainManager>().GhostTower();
        }
    }

    public void tryAgainClicked()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void notEnoughMoney()
    {
        if (!waitCoRunning)
        {
            infoText.SetActive(true);
            notEnoughMoneyText.text = "Not enough money!";

            StartCoroutine(Wait());

        }

    }

    public void maxLevel()
    {
        if (!waitCoRunning)
        {
            infoText.SetActive(true);
            notEnoughMoneyText.text = "Max Level!";

            StartCoroutine(Wait());

        }

    }

    public void bombsCooldownInfo()
    {
        if (!waitCoRunning)
        {
            infoText.SetActive(true);
            notEnoughMoneyText.text = "Bombs on cooldown!";

            StartCoroutine(Wait());

        }

    }

    public void CamClicked()
    {
        moveCamScript.GetComponent<MoveCamera>().CamSwitchView();
    }

    public void disableBombsButton(bool buttonState)
    {
        if (!buttonState)
        {
            bombButton.interactable = true;
        }
        else if (buttonState)
        {
            bombButton.interactable = false;
        }
    }

    public void TextColorChange(string textName)
    {
        if (textName == "Money")
        {

            moneyLerpColorText = true;

        }
        else if (textName == "Wave")
        {

            waveLerpColorText = true;

        }
        else if (textName == "Life")
        {

            livesLerpColorText = true;

        }
        else
        {
            Debug.Log("No or wrong string name");
        }



    }

    IEnumerator Wait()
    {

        waitCoRunning = true;

        yield return new WaitForSeconds(infoDelay);
        infoText.SetActive(false);
        waitCoRunning = false;

    }

    IEnumerator WaveInfoDelay()
    {

        yield return new WaitForSeconds(2);
        transform.Find("Final Wave").gameObject.SetActive(false);
        transform.Find("Boss Wave").gameObject.SetActive(false);

    }
}
