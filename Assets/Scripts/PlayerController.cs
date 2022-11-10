using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public GameObject normalTower;
    public GameObject ui;

    // Start is called before the first frame update
    void Start()
    {
        ui = GameObject.FindGameObjectWithTag("UI");
    }

    // Update is called once per frame
    void Update()
    {
        //Left click

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out RaycastHit raycasthit))
            {
                if (raycasthit.transform.CompareTag("Turret Base"))
                {

                    Instantiate(normalTower, raycasthit.point, transform.rotation);

                }
            }
        }

        //Right click => Deselect the tower

        if (Input.GetMouseButtonDown(1))
        {
            ui.GetComponent<UI>().normalTowerClicked = false;
        }
    }
}