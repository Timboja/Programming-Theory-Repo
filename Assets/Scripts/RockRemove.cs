using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RockRemove : MonoBehaviour
{

    public GameObject mainManager;
    public GameObject ui;
    public ParticleSystem removeExplositionBig;
    public ParticleSystem removeExplositionSmall;

    public string rockSize;

    public TextMeshProUGUI costRemovelTextUi;

    public void Start()
    {
        if (rockSize == "Big")
        {
            costRemovelTextUi.text = "Remove the rock for " + mainManager.GetComponent<MainManager>().costRemoveRockBig + "?";
        }
        else if(rockSize == "Small")
        {
            costRemovelTextUi.text = "Remove the rock for " + mainManager.GetComponent<MainManager>().costRemoveRocksmall + "?";
        }



    }

    public void RemoveClicked(string rockSize)
    {
        if (rockSize == "Big")
        {
            if (mainManager.GetComponent<MainManager>().money >= mainManager.GetComponent<MainManager>().costRemoveRockBig)
            {
                mainManager.GetComponent<MainManager>().money -= mainManager.GetComponent<MainManager>().costRemoveRockBig;

                removeExplositionBig.Play();

                Destroy(gameObject);
            }
            else
            {
                ui.GetComponent<UI>().notEnoughMoney();
            }
        }
        else if (rockSize == "Small")
        {
            if (mainManager.GetComponent<MainManager>().money >= mainManager.GetComponent<MainManager>().costRemoveRocksmall)
            {
                mainManager.GetComponent<MainManager>().money -= mainManager.GetComponent<MainManager>().costRemoveRocksmall;

                removeExplositionSmall.Play();

                Destroy(gameObject);
            }
            else
            {
                ui.GetComponent<UI>().notEnoughMoney();
            }
        }

    }
}
