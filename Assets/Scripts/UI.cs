using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UI : MonoBehaviour
{
    public GameObject mainManager;
    public GameObject spawnerObject;

    public GameObject ghostTower;
    public GameObject normalTower;

    public TextMeshProUGUI moneyText;
    public TextMeshProUGUI waveText;
    public TextMeshProUGUI livesText;

    public int moneyUI;
    public int waveUI;
    public int livesUI;

    public bool normalTowerClicked = false;

    // Start is called before the first frame update
    void Start()
    {
        spawnerObject.GetComponent<Spawner>();
        mainManager.GetComponent<MainManager>();
    }

    // Update is called once per frame
    void Update()
    {
        moneyUI = mainManager.GetComponent<MainManager>().money;
        moneyText.text = "Money: " + moneyUI;

        waveUI = mainManager.GetComponent<MainManager>().wave;
        waveText.text = "Wave: " + waveUI;

        livesUI = mainManager.GetComponent<MainManager>().live;
        livesText.text = "Lives: " + livesUI;

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
            normalTowerClicked = false;
        }

    }

    public void StartWave()
    {
        spawnerObject.GetComponent<Spawner>().SpawnWave();
    }

    //When the Tower Image is clicked

    public void TowerNormalClicked()
    {
        if (!normalTowerClicked)
        {
           // Debug.Log("Tower Clicked!");

            normalTowerClicked = true;

            Instantiate(ghostTower, transform.position, transform.rotation);
        }

    }

}
