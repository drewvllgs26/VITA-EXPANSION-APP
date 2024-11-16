using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TimerScript : MonoBehaviour
{
    public float timeRemaining = 180;
    public bool timeIsRunning = false;
    public AudioSource audioSource;
    public TMP_Text timeText;

    void Start()
    {
        if (timeText == null)
        {
            Debug.LogError("Error: timeText is not assigned!");
        }
    }

    void Update()
    {
        if (timeIsRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                DisplayTime(timeRemaining);
            }
            else
            {
                timeIsRunning = false;
                timeRemaining = 0;
                DisplayTime(timeRemaining); 
                audioSource.Play();
                timeText.text = string.Format("Time's Up!");
                timeText.fontSize = 120;
            }
        }
    }


    public void StartTimer()
    {
        timeIsRunning = !timeIsRunning;
    }

    void DisplayTime(float timeToDisplay)
    {

    timeToDisplay = Mathf.Max(timeToDisplay, 0);

    float minutes = Mathf.FloorToInt(timeToDisplay / 60);  
    float seconds = Mathf.FloorToInt(timeToDisplay % 60);  


    timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    public void ResetTimer()
    {
        timeIsRunning = false;
        audioSource.Stop();
        timeRemaining = 180;
        timeText.text = string.Format("3:00");
        timeText.fontSize = 230;
    }

}
