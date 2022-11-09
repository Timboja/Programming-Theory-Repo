using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    public float range;
    public float roationSpeed;
    public float attackSpeed;
    public int attackDamage;

    public bool enemyLocked = false;

    public bool attackCoRunning = false;

    public Transform enemyTransform;

    public GameObject detectionSphere;
    public GameObject bullet;
    public GameObject mainManager;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        UpdateTowerRange(range);

        //Script reference
        mainManager = GameObject.FindGameObjectWithTag("MainManager");

        enemyLocked = detectionSphere.GetComponent<EnemyDetection>().enemyLocked;
        enemyTransform = detectionSphere.GetComponent<EnemyDetection>().enemyTransform;

        mainManager.GetComponent<MainManager>().AttackDamageNormalTower = attackDamage;



        if (enemyLocked == true)
        {

            LockEnemy();

            if (!attackCoRunning)
            {

                StartCoroutine(Attack());

            }

        }

    }

    public void LockEnemy()
    {

        transform.LookAt(enemyTransform,Vector3.back);

    }

    IEnumerator Attack()
    {
        attackCoRunning = true;

        yield return new WaitForSeconds(attackSpeed);
        Instantiate(bullet, transform.position, transform.rotation);
        


        attackCoRunning = false;

    }

    public void UpdateTowerRange(float range)
    {
        //Updates the range of the tower
        detectionSphere.transform.localScale = new Vector3(range, range, range);
    }

}
