using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehavior : MonoBehaviour 
{
    public float firingSpeed;
    public Rigidbody bulletRb;
    public float outOfBoundsZ = 20;
    public float outOfBoundsX = 25;
    public int attackDamageBullet;

    private bool coRunning;
    private float destroyDelay = 0.3F;

    public GameObject mainManager;

    //public GameObject enemy;

    private void Start()
    {
        mainManager = GameObject.FindGameObjectWithTag("MainManager");

        // Initial force

        bulletRb = GetComponent<Rigidbody>();
        bulletRb.AddForce(bulletRb.transform.forward * firingSpeed, ForceMode.Impulse);

        attackDamageBullet = mainManager.GetComponent<MainManager>().AttackDamageNormalTower;

    }
    private void Update()
    {
        //Out of bounds detection Z,X und Destroy

        if (transform.position.z >= outOfBoundsZ || transform.position.z <= -outOfBoundsZ)
        {
            Destroy(gameObject);
        }
        else if (transform.position.x >= outOfBoundsX || transform.position.x <= -outOfBoundsX)
        {
            Destroy(gameObject);
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "EnemyCurrent")
        {

            //Delay on hit => otherwise no physic collition

            if(!coRunning)
            {

                StartCoroutine(Wait());
                Debug.Log("hit enemy");

            }

        }
        else if (other.gameObject.tag == "Enviroment")
        {

            Destroy(gameObject);
            Debug.Log("hit enviroment");

        }
    }
    IEnumerator Wait()
    {
        coRunning = true;

        yield return new WaitForSeconds(destroyDelay);
        Destroy(gameObject);

        coRunning = false;

    }
}
