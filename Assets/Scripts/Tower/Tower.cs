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

    public int upgradeCostNormal;
    public int upgradeCostFreeze;
    public int upgradeCostToxic;

    public int upgradeBaseCost;
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
    public GameObject turret;
    public GameObject musicPlayer;

    public MeshRenderer muzzleFlash;
    public float flashTime;

    public void Start()
    {

        mainManager = GameObject.FindGameObjectWithTag("MainManager");
        uI = GameObject.FindGameObjectWithTag("UI");
        musicPlayer = GameObject.FindGameObjectWithTag("MusicPlayer");

        CalcUpgradeCost(towerName);

    }

    //Calculates the next upgrade costs for active tower

    public void CalcUpgradeCost(string towerName)
    {
        if (towerName == "Normal Tower")
        {
            upgradeCostNormal = Mathf.RoundToInt((mainManager.GetComponent<MainManager>().baseCostNormalTower + level) * upgradeCostModifier);
        }
        else if (towerName == "Freeze Tower")
        {
            upgradeCostFreeze = Mathf.RoundToInt((mainManager.GetComponent<MainManager>().baseCostFreezeTower + level) * upgradeCostModifier);
        }
        else if (towerName == "Toxic Tower")
        {
            upgradeCostToxic = Mathf.RoundToInt((mainManager.GetComponent<MainManager>().baseCostToxicTower + level) * upgradeCostModifier);
        }
        else
        {
            Debug.Log("Error: Wrong or empty Towername variable!");
        }

    }

    public void LockEnemy()
    {

        turret.transform.LookAt(enemyTransform);

    }

    public void UpdateTowerRange(float range)
    {
        //Updates the range of the tower
        detectionSphere.transform.localScale = new Vector3(range, range, range);
    }

    public void UpgradeTowerNormal()
    {

        if (mainManager.GetComponent<MainManager>().money >= upgradeCostNormal)
        {
 
            if (level < maxLevel)
            {
                mainManager.GetComponent<MainManager>().money -= upgradeCostNormal;
                level++;

                range += 0.2F;
                attackSpeed -= 0.1F;
                attackDamage = Mathf.RoundToInt(attackDamage + (level / 2));

                CalcUpgradeCost(towerName);

                musicPlayer.GetComponent<MusicPlayer>().PlayUpgradeSound();
            }
            else
            {
                uI.GetComponent<UI>().maxLevel();
                musicPlayer.GetComponent<MusicPlayer>().PlayErrorSound();
            }
        }
        else
        {
            uI.GetComponent<UI>().notEnoughMoney();
            musicPlayer.GetComponent<MusicPlayer>().PlayErrorSound();
        }

    }

    public void UpgradeTowerFreeze()
    {

        if (mainManager.GetComponent<MainManager>().money >= upgradeCostFreeze)
        {

            if (level < maxLevel)
            {
                mainManager.GetComponent<MainManager>().money -= upgradeCostFreeze;
                level++;

                range += 0.1F;
                attackSpeed -= 0.2F;
                attackDamage = Mathf.RoundToInt(attackDamage + (level / 2));

                CalcUpgradeCost(towerName);

                musicPlayer.GetComponent<MusicPlayer>().PlayUpgradeSound();
            }
            else
            {
                uI.GetComponent<UI>().maxLevel();
                musicPlayer.GetComponent<MusicPlayer>().PlayErrorSound();
            }
        }
        else
        {
            uI.GetComponent<UI>().notEnoughMoney();
            musicPlayer.GetComponent<MusicPlayer>().PlayErrorSound();
        }

    }

    public void UpgradeTowerToxic()
    {
        if (mainManager.GetComponent<MainManager>().money >= upgradeCostToxic)
        {

            if (level < maxLevel)
            {
                mainManager.GetComponent<MainManager>().money -= upgradeCostToxic;
                level++;

                range += 0.1F;
                attackSpeed -= 0.2F;
                attackDamage = Mathf.RoundToInt(attackDamage + (level / 2));

                CalcUpgradeCost(towerName);

                musicPlayer.GetComponent<MusicPlayer>().PlayUpgradeSound();
            }
            else
            {
                uI.GetComponent<UI>().maxLevel();
                musicPlayer.GetComponent<MusicPlayer>().PlayErrorSound();
            }

        }
        else
        {
            uI.GetComponent<UI>().notEnoughMoney();
            musicPlayer.GetComponent<MusicPlayer>().PlayErrorSound();
        }

    }

}
