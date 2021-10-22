using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class GameOverMusic : MonoBehaviour
{
    public AudioSource gameOverMusic;

    public void Start()
    {
        gameOverMusic.volume = Menu.gameOverVolume;
    }
}