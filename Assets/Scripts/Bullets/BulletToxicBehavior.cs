using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletToxicBehavior : MonoBehaviour
{
    public float firingSpeed;
    public Rigidbody bulletRb;
    public float outOfBoundsZ = 20;
    public float outOfBoundsX = 25;
    public int attackDamageBullet;

    public int toxicStrenghtBullet;
    public float toxicSpeedBullet;
    public int toxicTicksBullet;

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
        if (other.gameObject.tag == "Toxic Tower" && !bulletInFlight)
        {
            attackDamageBullet = other.GetComponent<Tower>().attackDamage;
            toxicStrenghtBullet = other.GetComponent<ToxicTower>().toxicDamage;
            toxicSpeedBullet = other.GetComponent<ToxicTower>().toxicSpeed;
            toxicTicksBullet = other.GetComponent<ToxicTower>().toxicTicks;

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
        if (other.CompareTag("Enviroment") || other.CompareTag("Road"))
        {
            //Debug.Log("Hit Enviroment");
            bulletInFlight = false;
            StartCoroutine(DestroyDelay());

        }
    }
    IEnumerator DestroyDelay()
    {
        yield return new WaitForSeconds(1);
        Destroy(gameObject);
    }
}
