using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public GameObject normalTower;
    public GameObject currentUpgradeMenu;
    public GameObject ui;
    public GameObject mainManager;

    public LayerMask noSphere;

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

            if (Physics.Raycast(ray, out RaycastHit raycasthit, 100, noSphere))
            {
                //Checks if the ray hits a Turret Base and the tower build icon is clicked

                if (raycasthit.transform.CompareTag("Turret Base") && ui.GetComponent<UI>().normalTowerClicked)
                {
                    //Cecks if theres enough Money to buiild a tower

                    if (mainManager.GetComponent<MainManager>().money >= mainManager.GetComponent<MainManager>().baseCostNormalTower)
                    {
                        Instantiate(normalTower, raycasthit.point, transform.rotation);
                        mainManager.GetComponent<MainManager>().money -= mainManager.GetComponent<MainManager>().baseCostNormalTower;
                    }
                    else
                    {
                        Debug.Log("Not enough Money!");
                    }

                }
                else if (raycasthit.transform.CompareTag("Turret"))
                {
                    //Checks if theres a differnt upgrade menu open => closes it
                    if (currentUpgradeMenu != null)
                    {
                        currentUpgradeMenu.transform.Find("Upgrade Menu").gameObject.SetActive(false);
                        currentUpgradeMenu.transform.Find("Detection Sphere").GetComponent<MeshRenderer>().enabled = false;
                        currentUpgradeMenu = null;
                    }

                    currentUpgradeMenu = raycasthit.transform.gameObject;
                    currentUpgradeMenu.transform.Find("Upgrade Menu").gameObject.SetActive(true);
                    currentUpgradeMenu.transform.Find("Detection Sphere").GetComponent<MeshRenderer>().enabled = true;

                }
            }

        }

        //Right click => Deselect the tower and closes the upgrade menu if its open

        if (Input.GetMouseButtonDown(1))
        {
            ui.GetComponent<UI>().normalTowerClicked = false;

            //Checks if theres a differnt upgrade menu open => closes it
            if (currentUpgradeMenu != null)
            {
                currentUpgradeMenu.transform.Find("Upgrade Menu").gameObject.SetActive(false);
                currentUpgradeMenu.transform.Find("Detection Sphere").GetComponent<MeshRenderer>().enabled = false;
                currentUpgradeMenu = null;
            }
        }
    }
}
