using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UpgradeMenuUI : MonoBehaviour
{

    public TextMeshProUGUI towerNameText;
    public TextMeshProUGUI attackDamageText;
    public TextMeshProUGUI attackSpeedText;
    public TextMeshProUGUI attackRangeText;
    public TextMeshProUGUI costText;
    public TextMeshProUGUI levelText;

    public TextMeshProUGUI freezeText;
    public TextMeshProUGUI toxicText;

    private int attackDamageUi;
    private float attackSpeedUi;
    private float attackRangeUi;
    private int costUi;
    private int levelUi;

    private float freezeUi;
    private int toxicUi;

    public GameObject towerScript;
    public GameObject mainManager;
    public GameObject playerController;

    public bool exitClicked;


    // Start is called before the first frame update
    void Start()
    {
        //Script reference
        mainManager = GameObject.FindGameObjectWithTag("MainManager");
        playerController = GameObject.FindGameObjectWithTag("Player Controller");
        towerScript.GetComponent<NormalTower>();
        towerNameText.text = towerScript.GetComponent<Tower>().towerName;

    }

    // Update is called once per frame
    void Update()
    {

        UpdateUpgradeMenuUi();

    }

    //Abstraction

    public void UpdateUpgradeMenuUi()
    {
        towerNameText.text = towerScript.GetComponent<Tower>().towerName;

        attackDamageUi = towerScript.GetComponent<Tower>().attackDamage;
        attackDamageText.text = "Attack Damage: " + attackDamageUi;

        attackSpeedUi = towerScript.GetComponent<Tower>().attackSpeed;
        attackSpeedText.text = "Attack Speed: " + Mathf.Round(attackSpeedUi * 100.0f) * 0.01f;

        attackRangeUi = towerScript.GetComponent<Tower>().range;
        attackRangeText.text = "Attack Range: " + Mathf.Round(attackRangeUi * 100.0f) * 0.01f;

        levelUi = towerScript.GetComponent<Tower>().level;
        levelText.text = "Level: " + levelUi;

        if (towerScript.GetComponent<Tower>().towerName == "Normal Tower")
        {
            costUi = towerScript.GetComponent<Tower>().upgradeCostNormal;
            costText.text = "Upgrade Cost: " + costUi;
        }

        if (towerScript.GetComponent<Tower>().towerName == "Freeze Tower")
        {
            costUi = towerScript.GetComponent<Tower>().upgradeCostFreeze;
            costText.text = "Upgrade Cost: " + costUi;

            freezeUi = towerScript.GetComponent<FreezeTower>().freezeStrength;
            freezeText.text = "Freeze Strengt: " + Mathf.Round(freezeUi * 100.0f) * 0.01f;
        }

        if (towerScript.GetComponent<Tower>().towerName == "Toxic Tower")
        {
            costUi = towerScript.GetComponent<Tower>().upgradeCostToxic;
            costText.text = "Upgrade Cost: " + costUi;

            toxicUi = towerScript.GetComponent<ToxicTower>().toxicDamage;
            toxicText.text = "Toxic Strength: " + toxicUi;
        }
    }

    public void UpgradeClicked()
    {
        if (towerScript.GetComponent<Tower>().towerName == "Normal Tower")
        {
            towerScript.GetComponent<Tower>().UpgradeTowerNormal();
        }
        else if (towerScript.GetComponent<Tower>().towerName == "Freeze Tower")
        {
            towerScript.GetComponent<Tower>().UpgradeTowerFreeze();
        }
        else if (towerScript.GetComponent<Tower>().towerName == "Toxic Tower")
        {
            towerScript.GetComponent<Tower>().UpgradeTowerToxic();
        }

    }

    public void ExitClicked()
    {
        playerController.GetComponent<PlayerController>().ExitButton();
    }
}
