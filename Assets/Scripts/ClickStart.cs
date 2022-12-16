using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ClickStart : MonoBehaviour
{

    public AudioSource startGameSound;

    public void StartGame()
    {
        startGameSound.Play();
        SceneManager.LoadScene(1);
    }
}
