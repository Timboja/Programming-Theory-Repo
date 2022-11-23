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

        detectionSphere.transform.localScale = new Vector3(rangeGhostTower, rangeGhostTower, rangeGhostTower);
    }


    void Update()
    {
        //Object transform is bound to the mouse location on screen

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out RaycastHit raycasthit, 100, layersToHit))
        {
            transform.position = raycasthit.point;
        }

        //If rightclick is released destroy the object.

        if (!ui.GetComponent<UI>().normalTowerClicked && Input.GetMouseButtonUp(1) || !ui.GetComponent<UI>().freezeTowerClicked && Input.GetMouseButtonUp(1))
        {
            Destroy(gameObject);
        }

    }

}