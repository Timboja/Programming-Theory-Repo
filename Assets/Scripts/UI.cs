using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI : MonoBehaviour
{
    public GameObject spawnerObject;


    // Start is called before the first frame update
    void Start()
    {
        spawnerObject.GetComponent<Spawner>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartWave()
    {
        spawnerObject.GetComponent<Spawner>().SpawnWave();
    }
}
