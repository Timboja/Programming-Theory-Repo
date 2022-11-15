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

    private bool bulletInFlight;
    private bool coRunning;
    private float destroyDelay = 0.3F;

    public GameObject mainManager;

    //public GameObject enemy;

    private void Start()
    {

        // Initial force

        bulletRb = GetComponent<Rigidbody>();
        bulletRb.AddForce(bulletRb.transform.forward * firingSpeed, ForceMode.Impulse);

    }
    private void Update()
    {
        //Out of bounds detection Z,X und Destroy

        if (transform.position.z >= outOfBoundsZ || transform.position.z <= -outOfBoundsZ)
        {
            bulletInFlight = false;
            Destroy(gameObject);

        }
        else if (transform.position.x >= outOfBoundsX || transform.position.x <= -outOfBoundsX)
        {
            bulletInFlight = false;
            Destroy(gameObject);

        }
    }

    //Gives the bullet the attack damge of the tower

    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Turret" && !bulletInFlight)
        {
            attackDamageBullet = other.GetComponent<Tower>().attackDamage;

            bulletInFlight = true;
        }
    }

    public void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "Enemy")
        {

            //Delay on hit => otherwise no physic collition

            if(!coRunning)
            {

                StartCoroutine(Wait());

            }

        }
        else if (other.gameObject.tag == "Enviroment")
        {
            bulletInFlight = false;
            Destroy(gameObject);

        }
    }
    IEnumerator Wait()
    {
        coRunning = true;

        yield return new WaitForSeconds(destroyDelay);
        bulletInFlight = false;
        Destroy(gameObject);

        coRunning = false;

    }
}
