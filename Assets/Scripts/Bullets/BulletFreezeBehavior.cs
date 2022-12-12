using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletFreezeBehavior : MonoBehaviour
{
    public float firingSpeed;
    public Rigidbody bulletRb;
    public float outOfBoundsZ = 20;
    public float outOfBoundsX = 25;
    public int attackDamageBullet;

    public float freezeStrenghtBullet;

    private bool bulletInFlight;

    public GameObject mainManager;

    //public GameObject enemy;

    private void Start()
    {

        // Initial force

        bulletRb = GetComponent<Rigidbody>();
        bulletRb.AddForce(bulletRb.transform.forward * firingSpeed, ForceMode.Impulse);

    }

    //Gives the bullet the attack damge of the tower

    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Freeze Tower" && !bulletInFlight)
        {
            attackDamageBullet = other.GetComponent<Tower>().attackDamage;
            freezeStrenghtBullet = other.GetComponent<FreezeTower>().freezeStrength;

            bulletInFlight = true;
        }

    }

    public void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "Enemy")
        {

            bulletInFlight = false;
            Destroy(gameObject);

        }
        else if (other.gameObject.tag == "Enviroment")
        {
            bulletInFlight = false;
            Destroy(gameObject);

        }
    }

}
