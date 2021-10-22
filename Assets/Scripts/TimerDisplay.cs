using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerDisplay : MonoBehaviour
{
    public Text timerDisplay;
    public void Start()
    {
        timerDisplay.text = "Your time was: " + Mathf.Round(PlayerMove.gameTime) + " seconds.";
    }
}
