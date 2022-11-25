using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombController : MonoBehaviour
{
    public int bombControllerDamage;
    public int bombCountController;

    // Update is called once per frame
    void Update()
    {
        if (bombCountController <= 0)
        {
            Destroy(gameObject);
        }
    }
}
