using UnityEngine;
using UnityEngine.UI;

public class LapCounter : MonoBehaviour
{
    public int totalLaps = 3; 
    public Text lapText; 

    private int currentLap = 1;

    private void Start()
    {
        UpdateUI();
    }

    public void PlayerCrossedFinishLine()
    {
        if (currentLap < totalLaps)
        {
            currentLap++;
            UpdateUI();
        }
        else
        {
            lapText.text = "fin";
        }
    }

    private void UpdateUI()
    {
        lapText.text = "Lap " + currentLap + " / " + totalLaps;
    }
}
