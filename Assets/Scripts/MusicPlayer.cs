using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    public GameObject mainManager;

    public AudioSource audioPlayer;
    public AudioSource audioEffectsPlayer;

    public AudioClip mainMusic1;
    public AudioClip mainMusic2;
    public AudioClip battleMusic1;
    public AudioClip battleMusic2;
    public AudioClip winMusic;
    public AudioClip gameOverSound;

    public AudioClip buildSound;
    public AudioClip upgradeSound;
    public AudioClip errorSound;
    public AudioClip startWaveSound;
    public AudioClip looseLifeSound;

    // Start is called before the first frame update
    public void Start()
    {
        audioPlayer.clip = mainMusic1;
        audioPlayer.Play();
    }

    // Update is called once per frame
   public void PlayMainMusic(int wave)
    {

        if (wave == 5)
        {
            audioPlayer.Stop();
            audioPlayer.clip = battleMusic1;
            audioPlayer.Play();
        }
        else if (wave == 6)
        {
            audioPlayer.Stop();
            audioPlayer.clip = mainMusic2;
            audioPlayer.Play();
        }
        else if (wave == 10)
        {
            audioPlayer.Stop();
            audioPlayer.clip = battleMusic2;
            audioPlayer.Play();
        }

    }

   public void PlayWinMusic()
    {

        audioPlayer.Stop();
        audioPlayer.clip = winMusic;
        audioPlayer.Play();

    }

    public void PlayGameOverSound()
    {

        audioEffectsPlayer.Stop();
        audioEffectsPlayer.clip = gameOverSound;
        audioEffectsPlayer.Play();
        audioPlayer.Stop();

    }

    public void PlayUpgradeSound()
    {

        audioEffectsPlayer.Stop();
        audioEffectsPlayer.clip = upgradeSound;
        audioEffectsPlayer.Play();

    }

    public void PlayBuildSound()
    {

        audioEffectsPlayer.Stop();
        audioEffectsPlayer.clip = buildSound;
        audioEffectsPlayer.Play();

    }

    public void PlayErrorSound()
    {

        audioEffectsPlayer.Stop();
        audioEffectsPlayer.clip = errorSound;
        audioEffectsPlayer.Play();

    }

    public void PlaylooseLifeSound()
    {

        audioEffectsPlayer.Stop();
        audioEffectsPlayer.clip = looseLifeSound;
        audioEffectsPlayer.Play();

    }

    public void PlayStartWaveSound()
    {

        audioEffectsPlayer.Stop();
        audioEffectsPlayer.clip = startWaveSound;
        audioEffectsPlayer.Play();

    }

}
