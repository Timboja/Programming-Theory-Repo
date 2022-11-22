using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnlingEnemy : Enemy
{
    public int spawnlingsToHatch;

    // Start is called before the first frame update
    void Start()
    {
        mainManager = GameObject.FindGameObjectWithTag("MainManager");

        currentHealth = maxHealth;
        healthbar.SetMaxHealth(maxHealth);
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "BulletNormalTower")
        {
            damage = other.GetComponent<BulletBehavior>().attackDamageBullet;
            TakeDamage(damage,spawnlingsToHatch);
        }

        if (other.gameObject.tag == "Endzone")
        {
            LifeDamage(enemyDamage);
            Destroy(gameObject);
        }
    }
}
