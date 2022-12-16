using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalTower : Tower
{

    // Update is called once per frame
    public void Update()
    {
        UpdateTowerRange(range);

        enemyLocked = detectionSphere.GetComponent<EnemyDetection>().enemyLocked;
        enemyTransform = detectionSphere.GetComponent<EnemyDetection>().enemyTransform;

        if (enemyLocked == true && mainManager.GetComponent<MainManager>().gameIsActive == true)
        {

            LockEnemy();

            if (!attackCoRunning)
            {
                StartCoroutine(Flash());
                attackCoRunning = true;
                StartCoroutine(Attack());

            }

        }
    }
    IEnumerator Attack()
    {

        Instantiate(bullet, turret.transform.position + new Vector3(0,0.1F,0), turret.transform.rotation);
        yield return new WaitForSeconds(attackSpeed);
        attackCoRunning = false;

    }

    IEnumerator Flash()  
    {

        muzzleFlash.enabled = true;
        yield return new WaitForSeconds(flashTime);
        muzzleFlash.enabled = false;

    }

}
