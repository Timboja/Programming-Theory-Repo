using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreezeTower : Tower
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

                StartCoroutine(Flash());
                attackCoRunning = true;
                StartCoroutine(Attack());

            }

        }

    }
    IEnumerator Attack()
    {

        Instantiate(bullet, turret.transform.position, turret.transform.rotation);
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
