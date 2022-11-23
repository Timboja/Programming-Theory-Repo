using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    public float range;
    public float roationSpeed;
    public float attackSpeed;
    public int attackDamage;

    public string towerName;
    public int kills;

    public int upgradeCost;
    public float upgradeCostModifier;
    public int level;
    public int maxLevel;

    public bool enemyLocked = false;

    public bool attackCoRunning = false;

    public Transform enemyTransform;

    public GameObject detectionSphere;
    public GameObject bullet;
    public GameObject mainManager;
    public GameObject uI;

    public void Start()
    {
        mainManager = GameObject.FindGameObjectWithTag("MainManager");
        uI = GameObject.FindGameObjectWithTag("UI");
    }

    public void LockEnemy()
    {

        transform.Find("Sphere").LookAt(enemyTransform,Vector3.back);

    }

    public void UpdateTowerRange(float range)
    {
        //Updates the range of the tower
        detectionSphere.transform.localScale = new Vector3(range, range, range);
    }

    public void UpgradeTowerNormal()
    {
        if (mainManager.GetComponent<MainManager>().money >= ((upgradeCost + level) * upgradeCostModifier))
        {
 
            if (level < maxLevel)
            {
                mainManager.GetComponent<MainManager>().money -= Mathf.RoundToInt((upgradeCost + level) * upgradeCostModifier);
                level++;

                range += 0.2F;
                attackSpeed -= 0.1F;
                attackDamage = Mathf.RoundToInt(attackDamage + (level / 2));
            }
            else
            {
                uI.GetComponent<UI>().maxLevel();
            }
        }
        else
        {
            uI.GetComponent<UI>().notEnoughMoney();
        }

    }

    public void UpgradeTowerFreeze()
    {
        if (mainManager.GetComponent<MainManager>().money >= ((upgradeCost + level) * upgradeCostModifier))
        {

            if (level < maxLevel)
            {
                mainManager.GetComponent<MainManager>().money -= Mathf.RoundToInt((upgradeCost + level) * upgradeCostModifier);
                level++;

                range += 0.1F;
                attackSpeed -= 0.2F;
                attackDamage = Mathf.RoundToInt(attackDamage + (level / 2));

            }
            else
            {
                uI.GetComponent<UI>().maxLevel();
            }
        }
        else
        {
            uI.GetComponent<UI>().notEnoughMoney();
        }

    }

    public void UpgradeTowerToxic()
    {
        if (mainManager.GetComponent<MainManager>().money >= ((upgradeCost + level) * upgradeCostModifier))
        {

            if (level < maxLevel)
            {
                mainManager.GetComponent<MainManager>().money -= Mathf.RoundToInt((upgradeCost + level) * upgradeCostModifier);
                level++;

                range += 0.1F;
                attackSpeed -= 0.2F;
                attackDamage = Mathf.RoundToInt(attackDamage + (level / 2));
            }
            else
            {
                uI.GetComponent<UI>().maxLevel();
            }

        }
        else
        {
            uI.GetComponent<UI>().notEnoughMoney();
        }

    }

}
