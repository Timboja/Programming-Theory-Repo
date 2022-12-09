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

    public GameObject mainManager;

    //public GameObject enemy;

    private void Start()
    {

        // Initial force

        bulletRb = GetComponent<Rigidbody>();
        bulletRb.AddForce(bulletRb.transform.forward * firingSpeed, ForceMode.Impulse);

    }

    /*
    private void Update()
    {
        //Out of bounds detection Z,X und Destroy

        if (transform.position.z >= outOfBoundsZ || transform.position.z <= -outOfBoundsZ)
        {
            Debug.Log("");
            bulletInFlight = false;
            Destroy(gameObject);

        }
        else if (transform.position.x >= outOfBoundsX || transform.position.x <= -outOfBoundsX)
        {
            bulletInFlight = false;
            Destroy(gameObject);

        }
    }
    */

    //Gives the bullet the attack damge of the tower

    public void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Normal Tower") && !bulletInFlight)
        {
            attackDamageBullet = other.GetComponent<Tower>().attackDamage;

            bulletInFlight = true;
        }
    }

    public void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Enemy"))
        {

            bulletInFlight = false;
            Destroy(gameObject);

        }

        if (other.CompareTag("Enviroment") || other.CompareTag("Road"))
        {
            Debug.Log("Hit Enviroment");
            bulletInFlight = false;
            Destroy(gameObject);

        }
    }
}
