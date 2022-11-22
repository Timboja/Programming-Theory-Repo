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

    public float outOfBoundsZ;
    public float outOfBoundsX;

    public GameObject towerScript;
    public GameObject mainManager;

    


    // Start is called before the first frame update
    void Start()
    {
        //Script reference
        mainManager = GameObject.FindGameObjectWithTag("MainManager");

        towerScript.GetComponent<NormalTower>();
        towerNameText.text = towerScript.GetComponent<Tower>().towerName;

        //UI out of bounds check

        if (transform.position.x >= outOfBoundsX)
        {
            transform.position = transform.position + new Vector3(-6, 0, 0);
        }
        else if (transform.position.z <= outOfBoundsZ)
        {
            transform.position = transform.position + new Vector3(0, 0, 5);
        }
    }

    // Update is called once per frame
    void Update()
    {

        towerNameText.text = towerScript.GetComponent<Tower>().towerName;

        attackDamageUi = towerScript.GetComponent<Tower>().attackDamage;
        attackDamageText.text = "Attack Damage: " + attackDamageUi;

        attackSpeedUi = towerScript.GetComponent<Tower>().attackSpeed;
        attackSpeedText.text = "Attack Speed: " + attackSpeedUi;

        attackRangeUi = towerScript.GetComponent<Tower>().range;
        attackRangeText.text = "Attack Range: " + attackRangeUi;

        costUi = towerScript.GetComponent<Tower>().upgradeCost;
        costText.text = "Upgrade Cost: " + costUi;

        levelUi = towerScript.GetComponent<Tower>().level;
        levelText.text = "Level: " + levelUi;

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
}
