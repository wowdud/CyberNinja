using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class Menu : MonoBehaviour
{
    public AudioSource menuMus;
    public AudioSource optionsMus;
    public Slider menuSlider;
    public Slider optionsSlider;
    public static float gameVolume;
    public static float gameOverVolume;
    public float menuVolume;
    public float optionsVolume;
    public static float jumpVolume;
    public Slider gameSlider;
    public Slider gameOverSlider;
    public Slider jumpSFXSlider;
    // Start is called before the first frame update
    void Start()
    {

        float menuVolume = PlayerPrefs.GetFloat("menuVolume");
        float optionsVolume = PlayerPrefs.GetFloat("optionsVolume");
        gameVolume = PlayerPrefs.GetFloat("gameVolume");
        gameOverVolume = PlayerPrefs.GetFloat("gameOverVolume");
        jumpVolume = PlayerPrefs.GetFloat("jumpVolume");



        menuMus.volume = menuVolume;
        optionsMus.volume = optionsVolume;

        menuSlider.value = menuVolume;
        optionsSlider.value = optionsVolume;
        gameSlider.value = gameVolume;
        gameOverSlider.value = gameOverVolume;
        jumpSFXSlider.value = jumpVolume;

        menuSlider.onValueChanged.AddListener(delegate { VolumeSlider(); });
        optionsSlider.onValueChanged.AddListener(delegate { VolumeSlider(); });
        gameSlider.onValueChanged.AddListener(delegate { VolumeSlider(); });
        gameOverSlider.onValueChanged.AddListener(delegate { VolumeSlider(); });
        jumpSFXSlider.onValueChanged.AddListener(delegate { VolumeSlider(); });
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void PlayGame()
    {
        SceneManager.LoadScene(1);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void OptionsMus()
    {
        menuMus.Stop();
        optionsMus.Play();
    }

    public void MenuMus()
    {
        optionsMus.Stop();
        menuMus.Play();
    }

    public void VolumeSlider()
    {
        optionsVolume = optionsSlider.value;
        optionsMus.volume = optionsVolume;

        menuVolume = menuSlider.value;
        menuMus.volume = menuVolume;

        gameVolume = gameSlider.value;
        gameOverVolume = gameOverSlider.value;
        jumpVolume = jumpSFXSlider.value;

        PlayerPrefs.SetFloat("optionsVolume", optionsVolume);
        PlayerPrefs.SetFloat("menuVolume", menuVolume);
        PlayerPrefs.SetFloat("gameVolume", gameVolume);
        PlayerPrefs.SetFloat("gameOverVolume", gameOverVolume);
        PlayerPrefs.SetFloat("jumpVolume", jumpVolume);
        PlayerPrefs.Save();
    }

    public void Exit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
    Application.Quit();
#endif
    }
}
