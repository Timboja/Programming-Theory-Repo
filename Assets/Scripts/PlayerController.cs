using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public GameObject normalTower;
    public GameObject freezeTower;
    public GameObject toxicTower;
    public GameObject bombs;
    public GameObject currentUpgradeMenu;
    public GameObject ui;
    public GameObject mainManager;
    public GameObject musicPlayer;

    public Vector3 basePosition;

    public LayerMask noSphere;

    public float bombsYoffset;

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
                    //Cecks if theres enough Money to build a tower

                    if (mainManager.GetComponent<MainManager>().money >= mainManager.GetComponent<MainManager>().baseCostNormalTower)
                    {
                        //Deletes the Turret Base and places the tower on the position

                        basePosition = raycasthit.transform.position;
                        Destroy(raycasthit.transform.gameObject);

                        Instantiate(normalTower, basePosition, transform.rotation);
                        mainManager.GetComponent<MainManager>().money -= mainManager.GetComponent<MainManager>().baseCostNormalTower;

                        musicPlayer.GetComponent<MusicPlayer>().PlayBuildSound();

                    }
                    else
                    {
                        ui.GetComponent<UI>().notEnoughMoney();
                        musicPlayer.GetComponent<MusicPlayer>().PlayErrorSound();
                    }

                }
                else if (raycasthit.transform.CompareTag("Turret Base") && ui.GetComponent<UI>().freezeTowerClicked)
                {
                    //Cecks if theres enough Money to buiild a tower

                    if (mainManager.GetComponent<MainManager>().money >= mainManager.GetComponent<MainManager>().baseCostFreezeTower)
                    {

                        //Deletes the Turret Base and places the tower on the position

                        basePosition = raycasthit.transform.position;
                        Destroy(raycasthit.transform.gameObject);

                        Instantiate(freezeTower, basePosition, transform.rotation);
                        mainManager.GetComponent<MainManager>().money -= mainManager.GetComponent<MainManager>().baseCostFreezeTower;

                        musicPlayer.GetComponent<MusicPlayer>().PlayBuildSound();
                    }
                    else
                    {
                        ui.GetComponent<UI>().notEnoughMoney();
                        musicPlayer.GetComponent<MusicPlayer>().PlayErrorSound();
                    }

                }
                else if (raycasthit.transform.CompareTag("Turret Base") && ui.GetComponent<UI>().toxicTowerClicked)
                {
                    //Cecks if theres enough Money to build a tower

                    if (mainManager.GetComponent<MainManager>().money >= mainManager.GetComponent<MainManager>().baseCostToxicTower)
                    {

                        //Deletes the Turret Base and places the tower on the position

                        basePosition = raycasthit.transform.position;
                        Destroy(raycasthit.transform.gameObject);

                        Instantiate(toxicTower, basePosition, transform.rotation);
                        mainManager.GetComponent<MainManager>().money -= mainManager.GetComponent<MainManager>().baseCostToxicTower;

                        musicPlayer.GetComponent<MusicPlayer>().PlayBuildSound();
                    }
                    else
                    {
                        ui.GetComponent<UI>().notEnoughMoney();
                        musicPlayer.GetComponent<MusicPlayer>().PlayErrorSound();
                    }

                }
                else if (raycasthit.transform.CompareTag("Road") && ui.GetComponent<UI>().bombsClicked)
                {
                    //Cecks if theres enough Money to build a tower

                    if (mainManager.GetComponent<MainManager>().money >= mainManager.GetComponent<MainManager>().baseCostBombs)
                    {
                        Instantiate(bombs, raycasthit.point + new Vector3(0,bombsYoffset,0), transform.rotation);
                        mainManager.GetComponent<MainManager>().money -= mainManager.GetComponent<MainManager>().baseCostBombs;

                        musicPlayer.GetComponent<MusicPlayer>().PlayBuildSound();
                    }
                    else
                    {
                        ui.GetComponent<UI>().notEnoughMoney();
                        musicPlayer.GetComponent<MusicPlayer>().PlayErrorSound();
                    }

                }

                if (raycasthit.transform.CompareTag("Normal Tower") || raycasthit.transform.CompareTag("Freeze Tower") || raycasthit.transform.CompareTag("Toxic Tower") || raycasthit.transform.CompareTag("Rocks"))
                {
                    //Checks if theres a differnt upgrade menu open => closes it
                    if (currentUpgradeMenu != null)
                    {
                        currentUpgradeMenu.transform.Find("Upgrade Menu").gameObject.SetActive(false);

                        if (!raycasthit.transform.CompareTag("Rocks") && !currentUpgradeMenu.transform.CompareTag("Rocks"))
                        {
                            currentUpgradeMenu.transform.Find("Detection Sphere").GetComponent<MeshRenderer>().enabled = false;
                        }

                        currentUpgradeMenu = null;
                    }

                    currentUpgradeMenu = raycasthit.transform.gameObject;
                    currentUpgradeMenu.transform.Find("Upgrade Menu").gameObject.SetActive(true);
                    if (!raycasthit.transform.CompareTag("Rocks"))
                    {
                        currentUpgradeMenu.transform.Find("Detection Sphere").GetComponent<MeshRenderer>().enabled = true;
                    }


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

                if (!currentUpgradeMenu.transform.CompareTag("Rocks"))
                {
                    currentUpgradeMenu.transform.Find("Detection Sphere").GetComponent<MeshRenderer>().enabled = false;
                }

                currentUpgradeMenu = null;
            }
        }
    }

    public void ExitButton()
    {
        currentUpgradeMenu.transform.Find("Upgrade Menu").gameObject.SetActive(false);
        currentUpgradeMenu.transform.Find("Detection Sphere").GetComponent<MeshRenderer>().enabled = false;
        currentUpgradeMenu = null;
    }
}
