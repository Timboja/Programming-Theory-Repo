using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalEnemy : Enemy
{
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
            TakeDamage(damage);
        }
        if (other.gameObject.tag == "BulletFreezeTower")
        {
            damage = other.GetComponent<BulletFreezeBehavior>().attackDamageBullet;
            freeze = other.GetComponent<BulletFreezeBehavior>().freezeStrenghtBullet;
            TakeDamage(damage);
            TakeFreeze(freeze);
        }
        if (other.gameObject.tag == "BulletToxicTower")
        {
            damage = other.GetComponent<BulletToxicBehavior>().attackDamageBullet;
            toxicDamage = other.GetComponent<BulletToxicBehavior>().toxicStrenghtBullet;
            toxicSpeed = other.GetComponent<BulletToxicBehavior>().toxicSpeedBullet;
            toxicTicks = other.GetComponent<BulletToxicBehavior>().toxicTicksBullet;

            TakeDamage(damage);
            TakeToxic(toxicDamage);
        }

        if (other.gameObject.tag == "Endzone")
        {
            LifeDamage(enemyDamage);
            Destroy(gameObject);
        }
    }
}
