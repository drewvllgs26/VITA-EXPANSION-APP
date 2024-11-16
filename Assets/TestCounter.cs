using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TestCounter : MonoBehaviour
{
    public TMP_Text counterText;
    private int counterValue = 0;
    private int maxValue = 10;    
    private int minValue = 0;



    public void IncrementCounter()
    {
        if (counterValue < maxValue)
        {
            counterValue++;
            UpdateCounterText();
        }
    }

    public void DecrementCounter()
    {
        if (counterValue > minValue)
        {
            counterValue--;
            UpdateCounterText();
        }
    }



    private void UpdateCounterText()
    {
        counterText.text = counterValue.ToString();
    }
}
