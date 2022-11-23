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

    public int attackDamageUi;
    public float attackSpeedUi;
    public float attackRangeUi;
    public int costUi;
    public int levelUi;

    public float freezeUi;
    public int toxicUi;

    public float outOfBoundsZBottom;
    public float outOfBoundsZTop;
    public float outOfBoundsXRight;
    public float outOfBoundsXLeft;

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

        //UI out of bounds check

        if (transform.position.x >= outOfBoundsXRight)
        {

            //Debug.Log(transform.position.x + " >= outOfBoundsXRight: " + outOfBoundsXRight);
            transform.position = transform.position + new Vector3(-6, 0, 0);

        }
        else if (transform.position.x <= outOfBoundsXLeft)
        {

            //Debug.Log(transform.position.x + " <= outOfBoundsXLeft: " + outOfBoundsXLeft);
            transform.position = transform.position + new Vector3(6, 0, 4);

        }
        else if (transform.position.z <= outOfBoundsZBottom)
        {

            //Debug.Log(transform.position.z + " <= outOfBoundsZBottom: " + outOfBoundsZBottom);
            transform.position = transform.position + new Vector3(0, 0, 4);

        }
        else if (transform.position.z >= outOfBoundsZTop)
        {

            //Debug.Log(transform.position.z + " >= outOfBoundsZTop: " + outOfBoundsZTop);
            transform.position = transform.position + new Vector3(0, 0, -1);

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

        if (towerScript.GetComponent<Tower>().towerName == "Freeze Tower")
        {
            freezeUi = towerScript.GetComponent<FreezeTower>().freezeStrength;
            freezeText.text = "Freeze Strengt: " + freezeUi;
        }

        if (towerScript.GetComponent<Tower>().towerName == "Toxic Tower")
        {
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
