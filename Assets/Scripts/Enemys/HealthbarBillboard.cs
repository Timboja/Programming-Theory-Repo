using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthbarBillboard : MonoBehaviour
{

    public Transform cam;
    

    public void Start()
    {
        cam = GameObject.FindGameObjectWithTag("MainCamera").transform;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.LookAt(transform.position + cam.forward);
    }
}
