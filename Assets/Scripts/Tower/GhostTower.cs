using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostTower : MonoBehaviour
{

    private float rangeGhostTower;

    //public Transform ghostTowerTransform;

    public GameObject mainManager;
    public GameObject detectionSphere;
    public GameObject ui;
    public LayerMask layersToHit;
    

    // Start is called before the first frame update
    void Start()
    {

        //Script Reference

        ui = GameObject.FindGameObjectWithTag("UI");
        mainManager = GameObject.FindGameObjectWithTag("MainManager");

        if (ui.GetComponent<UI>().normalTowerClicked)
        {
            rangeGhostTower = mainManager.GetComponent<MainManager>().baseRangeNormalTower;
        }
        if (ui.GetComponent<UI>().freezeTowerClicked)
        {
            rangeGhostTower = mainManager.GetComponent<MainManager>().baseRangeFreezeTower;
        }
        if (ui.GetComponent<UI>().toxicTowerClicked)
        {
            rangeGhostTower = mainManager.GetComponent<MainManager>().baseRangeToxicTower;
        }

        //Prevent bombs from acessing the detection sphere => they dont have it

        if (!ui.GetComponent<UI>().bombsClicked)
        {
            detectionSphere.transform.localScale = new Vector3(rangeGhostTower, rangeGhostTower, rangeGhostTower);
        }

    }


    void Update()
    {
        //Object transform is bound to the mouse location on screen

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out RaycastHit raycasthit, 100, layersToHit))
        {
            transform.position = raycasthit.point;
        }

        if (ui.GetComponent<UI>().killGhost == true)
        {
            ui.GetComponent<UI>().killGhost = false;
            Destroy(gameObject);
        }


        //If rightclick is released destroy the object.

        if(Input.GetMouseButtonUp(1))
        {
            ui.GetComponent<UI>().normalTowerClicked = false;
            ui.GetComponent<UI>().freezeTowerClicked = false;
            ui.GetComponent<UI>().toxicTowerClicked = false;
            ui.GetComponent<UI>().bombsClicked = false;
            Destroy(gameObject);
        }

    }

}
