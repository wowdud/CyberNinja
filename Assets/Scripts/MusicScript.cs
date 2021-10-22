using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class MusicScript : MonoBehaviour
{
    public AudioSource gameMusic;
    public AudioSource jumpSFX;

    public void Start()
    {
        gameMusic.volume = Menu.gameVolume;
        jumpSFX.volume = Menu.jumpVolume;
    }
}
