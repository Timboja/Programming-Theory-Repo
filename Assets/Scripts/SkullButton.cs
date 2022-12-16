using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkullButton : MonoBehaviour
{
    public GameObject mainManager;
    public GameObject canvas;
    public AudioSource buttonSound;

    public GameObject firstText;
    public GameObject secondText;

    public GameObject firstButtonText;
    public GameObject secondButtonText;

    private int firstClick = 0;

    public void SkullButtonClicked()
    {
        firstClick++;

        if (firstClick == 1)
        {
            firstText.SetActive(false);
            secondText.SetActive(true);
            firstButtonText.SetActive(false);
            secondButtonText.SetActive(true);

        }
        if (firstClick == 2)
        {
            buttonSound.Play();
            mainManager.GetComponent<MainManager>().GameStart();
            canvas.SetActive(false);
        }


    }
}
