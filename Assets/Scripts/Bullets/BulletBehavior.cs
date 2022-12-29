using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehavior : MonoBehaviour 
{
    [SerializeField]
    private float firingSpeed;
    public Rigidbody bulletRb;
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
