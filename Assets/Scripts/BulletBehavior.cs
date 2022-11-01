using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehavior : EnemyDetection
{
    public float firingSpeed;

    //public GameObject enemy;

    // Start is called before the first frame update
    void update()
    {
        Vector3 goToDirection = (enemyTransform - transform.position);

        transform.position += transform.forward * Time.deltaTime * firingSpeed;

    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "EnemyCurrent")
        {
            // gegner leben --
            Debug.Log("hit");
            Destroy(gameObject);
        }
        else
        {
            //Destroy(gameObject);
        }
    }
}
