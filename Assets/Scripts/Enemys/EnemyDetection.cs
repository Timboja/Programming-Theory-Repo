using UnityEngine;

public class EnemyDetection : MonoBehaviour
{
    public Transform enemyTransform;
    public GameObject enemyCurrent;
    public GameObject enemyNext;

    public bool enemyLocked;

    public void Update()
    {

        //Feuer einstellen falls Enemy zerstört wurde

        if (enemyTransform == null && enemyLocked == true)
        {
            enemyLocked = false;
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        //Chicks if a Enemy is in range and its the first Enemy. 

        if (other.gameObject.tag == "Enemy" && enemyCurrent == null)
        {

            enemyCurrent = other.gameObject;
            enemyTransform = enemyCurrent.gameObject.transform;

            //Sets the lock for the tower used in Tower.cs

            enemyLocked = true;

        }

        //Checks if there is currently a enemy in the tower lock theen marks it as next target.

        else if (other.gameObject.tag == "Enemy" && enemyCurrent != null)
        {
            enemyNext = other.gameObject;

        }
        
    }

    //Resets the lock and tagging of the enemy when he leaves the tower range.

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Enemy" && enemyCurrent != null)
        {

            enemyLocked = false;
            enemyCurrent = null;
            enemyTransform = null;

            //Checks if there is anothere enemy in range of the tower then locks that enemy.

            if (enemyNext != null)
            {
                enemyCurrent = enemyNext;
                enemyNext = null;
                enemyTransform = enemyCurrent.gameObject.transform;


                enemyLocked = true;

            }
        }

    }

}
