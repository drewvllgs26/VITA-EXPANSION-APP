using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Counter : MonoBehaviour
{
    [System.Serializable]
    public class PlayerUI
    {
        public TMP_Text counterScoreText;
        public TMP_Text placementText;
    }

    public PlayerUI[] players = new PlayerUI[4];
    private int[] counterValues = new int[4];
    private int maxValue = 15;
    private int minValue = 0;

    void Start()
    {
        LoadValues(); // Load previously saved values
        UpdatePlacements();
    }

    public void IncrementCounter(int playerIndex)
    {
        if (counterValues[playerIndex] < maxValue)
        {
            counterValues[playerIndex]++;
            SaveValue(playerIndex);
            UpdateCounterText(playerIndex);
            UpdatePlacements();
        }
    }

    public void DecrementCounter(int playerIndex)
    {
        if (counterValues[playerIndex] > minValue)
        {
            counterValues[playerIndex]--;
            SaveValue(playerIndex); 
            UpdateCounterText(playerIndex);
            UpdatePlacements();
        }
    }

    private void UpdateCounterText(int playerIndex)
    {
        players[playerIndex].counterScoreText.text = counterValues[playerIndex].ToString();
    }

    private void UpdatePlacements()
    {
        int[] sortedIndices = { 0, 1, 2, 3 };

        System.Array.Sort(sortedIndices, (a, b) =>
        {
            if (counterValues[a] != counterValues[b])
                return counterValues[b].CompareTo(counterValues[a]);
            return a.CompareTo(b);
        });

        string[] placementStrings = { "1st", "2nd", "3rd", "4th" };
        for (int i = 0; i < sortedIndices.Length; i++)
        {
            int playerIndex = sortedIndices[i];
            players[playerIndex].placementText.text = placementStrings[i];
        }
    }

    private void SaveValue(int playerIndex)
    {
        PlayerPrefs.SetInt("Player" + playerIndex + "Score", counterValues[playerIndex]);
        PlayerPrefs.Save();
    }

    private void LoadValues()
    {
        for (int i = 0; i < players.Length; i++)
        {
            counterValues[i] = PlayerPrefs.GetInt("Player" + i + "Score", 0);
            players[i].counterScoreText.text = counterValues[i].ToString();
        }
    }

    public void ResetCounters()
    {
    for (int i = 0; i < players.Length; i++)
    {
        counterValues[i] = 0;
        players[i].counterScoreText.text = "0";
        players[i].placementText.text = "4th";
        PlayerPrefs.DeleteKey("Player" + i + "Score");
    }

    PlayerPrefs.Save();
    UpdatePlacements();
    }

}











