using UnityEngine;
using UnityEngine.UI;

public class TimerManager : MonoBehaviour
{
    public Text timerText; // Reference to the UI Text element
    private float startTime;
    private bool isRaceStarted = false;

    private void Start()
    {
        // Initialize the timer when the scene loads
        ResetTimer();
    }

    private void Update()
    {
        if (isRaceStarted)
        {
            // Update the timer
            float elapsedTime = Time.time - startTime;
            UpdateTimerText(elapsedTime);
        }
    }

    public void StartRace()
    {
        // Start the timer when the race begins
        startTime = Time.time;
        isRaceStarted = true;
    }

    public void ResetTimer()
    {
        // Reset the timer to zero
        UpdateTimerText(0f);
        isRaceStarted = false;
    }

    private void UpdateTimerText(float time)
    {
        int minutes = Mathf.FloorToInt(time / 60);
        int seconds = Mathf.FloorToInt(time % 60);
        int milliseconds = Mathf.FloorToInt((time * 1000) % 1000);

        string timeString = string.Format("{0:00}:{1:00}:{2:000}", minutes, seconds, milliseconds);
        timerText.text = "Time: " + timeString;
    }
}
