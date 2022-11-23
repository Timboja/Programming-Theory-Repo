using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public int maxHealth;
    public int currentHealth;
    public int damage;
    public int bounty;

    public int enemyDamage;

    public float freeze;

    public int toxicDamage;
    public int toxicTicks;
    public float toxicSpeed;

    public bool enemyDown;
    public bool hasDamage;

    public GameObject mainManager;
    public HealthBar healthbar;
    public GameObject healthbarCanvas;
    public GameObject spawnlings;

    public void TakeDamage(int damage)
    {

        currentHealth -= damage;

        healthbar.SetHealth(currentHealth);

        if (currentHealth <= 0 && !enemyDown)
        {

            mainManager.GetComponent<MainManager>().money += bounty;

            Destroy(gameObject);
            enemyDown = true;

        }

    }

    //Polymorphysm

    //Spawnling Overload

    public void TakeDamage(int damage,int spawnlingNumber)
    {

        currentHealth -= damage;

        healthbar.SetHealth(currentHealth);

        if (currentHealth <= 0 && !enemyDown)
        {

            mainManager.GetComponent<MainManager>().money += bounty;


            for (int i = 0; i < spawnlingNumber; i++)
            {
                Instantiate(spawnlings, transform.position, transform.rotation);
            }


            Destroy(gameObject);
            enemyDown = true;

        }

    }

    public void TakeFreeze(float freeze)
    {

        if (GetComponent<NavMeshAgent>().speed > 0.6)
        {
            GetComponent<NavMeshAgent>().speed -= freeze;
        }
        
    }

    public void TakeToxic(int toxicDamage)
    {
        StartCoroutine(ToxicDamage(toxicDamage));
    }

    public void LifeDamage(int damage)
    {

        mainManager.GetComponent<MainManager>().live -= damage;

    }

    IEnumerator ToxicDamage(int toxicDamage)
    {
        for (int i = 0; i < toxicTicks; i++)
        {
            yield return new WaitForSeconds(toxicSpeed);
            TakeDamage(toxicDamage);
        }

    }
}
