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

    public int attackDamageUi;
    public float attackSpeedUi;
    public float attackRangeUi;
    public int costUi;
    public int levelUi;

    public GameObject towerScript;
    public GameObject mainManager;

    // Start is called before the first frame update
    void Start()
    {
        //Script reference
        mainManager = GameObject.FindGameObjectWithTag("MainManager");

        towerScript.GetComponent<NormalTower>();
        towerNameText.text = towerScript.GetComponent<NormalTower>().towerName;
    }

    // Update is called once per frame
    void Update()
    {

        towerNameText.text = towerScript.GetComponent<NormalTower>().towerName;

        attackDamageUi = towerScript.GetComponent<NormalTower>().attackDamage;
        attackDamageText.text = "Attack Damage: " + attackDamageUi;

        attackSpeedUi = towerScript.GetComponent<NormalTower>().attackSpeed;
        attackSpeedText.text = "Attack Speed: " + attackSpeedUi;

        attackRangeUi = towerScript.GetComponent<NormalTower>().range;
        attackRangeText.text = "Attack Range: " + attackRangeUi;

        costUi = towerScript.GetComponent<NormalTower>().upgradeCost;
        costText.text = "Upgrade Cost: " + costUi;

        levelUi = towerScript.GetComponent<NormalTower>().level;
        levelText.text = "Level: " + levelUi;

    }

    public void UpgradeClicked()
    {
        towerScript.GetComponent<Tower>().UpgradeTower();
    }
}
