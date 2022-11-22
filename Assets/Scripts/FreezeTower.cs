using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreezeTower : Tower
{

    public float freezeStrength;

    // Start is called before the first frame update
    void Start()
    {

        //Script reference
        mainManager = GameObject.FindGameObjectWithTag("MainManager");

    }

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
