using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.PlayerLoop;

public class Timer : MonoBehaviour
{
    private float timeRemaining = 300.0f; 
    public TextMeshProUGUI timerText;
    
    private bool timesUp = false;

    void Start()
    {
        StartCoroutine(StartTimer());
    }

    IEnumerator StartTimer()
    {
        while (timeRemaining > 0)
        {
            yield return new WaitForSeconds(1.0f);
            timeRemaining -= 1.0f;
            UpdateUIText();
        }

        timesUp = true;

        PlayerPrefs.SetInt("timesUp", timesUp ? 1 : 0);
        PlayerPrefs.Save();

        timesUp = false;
        SceneManager.LoadScene("PopupScene");
    }

    void UpdateUIText()
    {
        
        int minutes = Mathf.FloorToInt(timeRemaining / 60);
        int seconds = Mathf.FloorToInt(timeRemaining % 60);

        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
