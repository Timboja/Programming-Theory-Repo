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
    public GameObject musicPlayer;
    public GameObject uI;

    public AudioSource hitSound;
    public AudioSource deathSound;

    public ParticleSystem enemyDeathExplosition;

    //Abstraction

    public void TakeDamage(int damage)
    {

        currentHealth -= damage;

        healthbar.SetHealth(currentHealth);

        hitSound.Play();

        if (currentHealth <= 0 && !enemyDown)
        {

            mainManager.GetComponent<MainManager>().money += bounty;
            uI.GetComponent<UI>().TextColorChange("Money");

            Instantiate(enemyDeathExplosition,transform.position,transform.rotation);

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

        hitSound.Play();

        if (currentHealth <= 0 && !enemyDown)
        {

            mainManager.GetComponent<MainManager>().money += bounty;
            uI.GetComponent<UI>().TextColorChange("Money");

            for (int i = 0; i < spawnlingNumber; i++)
            {

                Instantiate(spawnlings, transform.position, transform.rotation);

            }

            Instantiate(enemyDeathExplosition, transform.position, transform.rotation);

            Destroy(gameObject);
            enemyDown = true;

        }

    }

    //Abstraction

    public void TakeFreeze(float freeze)
    {

        if (GetComponent<NavMeshAgent>().speed > 0.6)
        {
            GetComponent<NavMeshAgent>().speed -= freeze;
        }
        
    }

    //Abstraction

    public void TakeToxic(int toxicDamage)
    {
        StartCoroutine(ToxicDamage(toxicDamage));
    }

    //Polymorphysm

    public void TakeToxic(int toxicDamage, int spawnlingNumber)
    {
        StartCoroutine(ToxicDamageSpawnling(toxicDamage, spawnlingNumber));
    }

    public void LifeDamage(int damage)
    {

        mainManager.GetComponent<MainManager>().live -= damage;
        uI.GetComponent<UI>().TextColorChange("Life");
        musicPlayer.GetComponent<MusicPlayer>().PlaylooseLifeSound();

    }

    IEnumerator ToxicDamageSpawnling(int toxicDamage, int spawnlingNumber)
    {
        for (int i = 0; i < toxicTicks; i++)
        {
            yield return new WaitForSeconds(toxicSpeed);
            TakeDamage(toxicDamage, spawnlingNumber);
        }

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
