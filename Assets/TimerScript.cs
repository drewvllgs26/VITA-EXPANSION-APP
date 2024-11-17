// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEngine.UI;
// using TMPro;

// public class TimerScript : MonoBehaviour
// {
//     public float timeRemaining = 120;
//     public bool timeIsRunning = false;
//     public AudioSource audioSource;
//     public TMP_Text timeText;

//     void Start()
//     {
//         if (timeText == null)
//         {
//             Debug.LogError("Error: timeText is not assigned!");
//         }
//     }

//     void Update()
//     {
//         if (timeIsRunning)
//         {
//             if (timeRemaining > 0)
//             {
//                 timeRemaining -= Time.deltaTime;
//                 DisplayTime(timeRemaining);
//             }
//             else
//             {
//                 timeIsRunning = false;
//                 timeRemaining = 0;
//                 DisplayTime(timeRemaining); 
//                 timeText.text = string.Format("Time's Up!");
//                 timeText.fontSize = 120;
//             }
//         }
//     }


//     public void StartTimer()
//     {
//         if (timeIsRunning)
//         {
//         timeIsRunning = false;
//         audioSource.Pause();
//         }
//         else
//         {
//         timeIsRunning = true;
//         audioSource.Play();
//         }
//     }


//     void DisplayTime(float timeToDisplay)
//     {

//     timeToDisplay = Mathf.Max(timeToDisplay, 0);

//     float minutes = Mathf.FloorToInt(timeToDisplay / 60);  
//     float seconds = Mathf.FloorToInt(timeToDisplay % 60);  


//     timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
//     }

//     public void ResetTimer()
//     {
//         timeIsRunning = false;
//         audioSource.Stop();
//         timeRemaining = 120;
//         timeText.text = string.Format("2:00");
//         timeText.fontSize = 230;
//     }

// }
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TimerScript : MonoBehaviour
{
    public float timeRemaining = 120;
    public bool timeIsRunning = false;
    public AudioSource audioSource;
    public TMP_Text timeText;
    public GameObject[] objectsToDisable; // Array of GameObjects to disable when timer reaches 0

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
                audioSource.Stop();
                DisplayTime(timeRemaining); 
                timeText.text = "Time's Up!";
                timeText.fontSize = 120;
                
                // Disable specified GameObjects
                DisableObjects();
            }
        }
    }

    public void StartTimer()
    {
        if (timeIsRunning)
        {
            timeIsRunning = false;
            audioSource.Pause();
        }
        else
        {
            timeIsRunning = true;
            audioSource.Play();
        }
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
        timeRemaining = 120;
        timeText.text = "2:00";
        timeText.fontSize = 230;
    }

    // Method to disable GameObjects
    private void DisableObjects()
    {
        foreach (GameObject obj in objectsToDisable)
        {
            if (obj != null)
            {
                obj.SetActive(false);
            }
        }
    }
}
