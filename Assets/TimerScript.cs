using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TimerScript : MonoBehaviour
{
    public float timeRemaining = 180;  // Set to 3 minutes (180 seconds)
    public bool timeIsRunning = false;
    public AudioSource audioSource;
    public TMP_Text timeText;

    // Start is called before the first frame update
    void Start()
    {
        // Check if the timeText is not assigned
        if (timeText == null)
        {
            Debug.LogError("Error: timeText is not assigned!");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (timeIsRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;  // Subtract to countdown
                DisplayTime(timeRemaining);
            }
            else
            {
                // Timer reaches zero, stop it
                timeIsRunning = false;
                timeRemaining = 0;
                DisplayTime(timeRemaining);  // Ensure the time is shown as 00:00 when it finishes
                audioSource.Play();
            }
        }
    }

    // This function starts the timer when the button is clicked
    public void StartTimer()
    {
        timeIsRunning = true;
    }

    // This function will display the time in the format "minutes : seconds"
    void DisplayTime(float timeToDisplay)
    {
    // Make sure timeToDisplay is not negative
    timeToDisplay = Mathf.Max(timeToDisplay, 0);

    // Get minutes and seconds
    float minutes = Mathf.FloorToInt(timeToDisplay / 60);  // Get minutes
    float seconds = Mathf.FloorToInt(timeToDisplay % 60);  // Get seconds

    // Display time in "MM : SS" format
    timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
