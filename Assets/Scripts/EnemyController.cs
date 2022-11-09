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

}
