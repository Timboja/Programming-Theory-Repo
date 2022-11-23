using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalTower : Tower
{

    // Update is called once per frame
    void Update()
    {
        UpdateTowerRange(range);

        enemyLocked = detectionSphere.GetComponent<EnemyDetection>().enemyLocked;
        enemyTransform = detectionSphere.GetComponent<EnemyDetection>().enemyTransform;

        if (enemyLocked == true && mainManager.GetComponent<MainManager>().gameIsActive == true)
        {

            LockEnemy();

            if (!attackCoRunning)
            {

                attackCoRunning = true;
                StartCoroutine(Attack());

            }

        }
    }
    IEnumerator Attack()
    {


        Instantiate(bullet, transform.Find("Sphere").position, transform.Find("Sphere").rotation);
        yield return new WaitForSeconds(attackSpeed);
        attackCoRunning = false;

    }
}
