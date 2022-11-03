using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    public int maxHealth;
    public int currentHealth;
    public int damage;

    public HealthBar healthbar;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthbar.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {



    }
    void TakeDamage(int damage)
    {

        currentHealth -= damage;

        healthbar.SetHealth(currentHealth);

        if (currentHealth <= 0)
        {
            Destroy(gameObject);
            //Money++ ?
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
