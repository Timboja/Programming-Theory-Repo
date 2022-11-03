using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    //public Camera cam;

    public NavMeshAgent agent;

    public GameObject endzone;

    void Start()
    {
        endzone = GameObject.FindGameObjectWithTag("Endzone");

        agent.SetDestination(endzone.transform.position);
    }
    // Update is called once per frame
    void Update()
    {



    }
}

//Agent goes where the mouse clicks on the screen

/*
if (Input.GetMouseButtonDown(0))
{
    Ray ray = cam.ScreenPointToRay(Input.mousePosition);
    RaycastHit hit;

    if (Physics.Raycast(ray, out hit))
    {
        agent.SetDestination(hit.point);
    }
}
*/