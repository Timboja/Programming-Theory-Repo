using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public GameObject normalTower;
    public GameObject freezeTower;
    public GameObject toxicTower;
    public GameObject spikes;
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
                //Raycast sichtbar machen

                Vector3 rayStart = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                Debug.DrawRay(rayStart, raycasthit.point - rayStart, Color.red, 4F);

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
                else if (raycasthit.transform.CompareTag("Turret Base") && ui.GetComponent<UI>().freezeTowerClicked)
                {
                    //Cecks if theres enough Money to buiild a tower

                    if (mainManager.GetComponent<MainManager>().money >= mainManager.GetComponent<MainManager>().baseCostFreezeTower)
                    {
                        Instantiate(freezeTower, raycasthit.point, transform.rotation);
                        mainManager.GetComponent<MainManager>().money -= mainManager.GetComponent<MainManager>().baseCostFreezeTower;
                    }
                    else
                    {
                        Debug.Log("Not enough Money!");
                    }

                }
                else if (raycasthit.transform.CompareTag("Turret Base") && ui.GetComponent<UI>().toxicTowerClicked)
                {
                    //Cecks if theres enough Money to build a tower

                    if (mainManager.GetComponent<MainManager>().money >= mainManager.GetComponent<MainManager>().baseCostToxicTower)
                    {
                        Instantiate(toxicTower, raycasthit.point, transform.rotation);
                        mainManager.GetComponent<MainManager>().money -= mainManager.GetComponent<MainManager>().baseCostToxicTower;
                    }
                    else
                    {
                        Debug.Log("Not enough Money!");
                    }

                }

                if (raycasthit.transform.CompareTag("Normal Tower") || raycasthit.transform.CompareTag("Freeze Tower") || raycasthit.transform.CompareTag("Toxic Tower"))
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
            ui.GetComponent<UI>().freezeTowerClicked = false;
            ui.GetComponent<UI>().toxicTowerClicked = false;


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
