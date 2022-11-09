using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    public int maxHealth;
    public int currentHealth;
    public int damage;
    public int bounty;

    public bool enemyDown;

    public GameObject mainManager;
    public HealthBar healthbar;

    // Start is called before the first frame update
    void Start()
    {
        mainManager = GameObject.FindGameObjectWithTag("MainManager");

        currentHealth = maxHealth;
        healthbar.SetMaxHealth(maxHealth);
    }

    void TakeDamage(int damage)
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

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "BulletNormalTower")
        {
            damage = other.GetComponent<BulletBehavior>().attackDamageBullet;
            TakeDamage(damage);
        }
    }
}
