using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bombs : MonoBehaviour
{
    //Encapsulation

    public int bombDamage { get; private set; }
    public int bombCount { get; private set; }

    public GameObject bombController;

    // Start is called before the first frame update
    void Start()
    {
        bombDamage = bombController.GetComponent<BombController>().bombControllerDamage;
        bombCount = bombController.GetComponent<BombController>().bombCountController;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            bombController.GetComponent<BombController>().bombCountController--;
            Destroy(gameObject);
        }

        if (collision.gameObject.CompareTag("Enviroment"))
        {
            //Debug.Log("Enviroment colision");
            bombController.GetComponent<BombController>().bombCountController--;
            Destroy(gameObject);
        }

    }
}
