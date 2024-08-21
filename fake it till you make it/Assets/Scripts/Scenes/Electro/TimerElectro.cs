using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.PlayerLoop;

public class TimerElectro : MonoBehaviour
{
    private float timeRemaining = 180.0f; 
    public TextMeshProUGUI timerText;
    public static TimerElectro Instance;

    private bool timesUp = false;

    void Start()
    {
        StartCoroutine(StartTimer());
    }
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            //DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Update()
    {
        if (SceneManager.GetActiveScene().name == "Lobby")
        {
            Destroy(gameObject);
        }
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

    public float GetTimeLeft()
    {
        return timeRemaining;
    }

    public void SetTimeLeft(float timeLeft)
    {
        timeRemaining = timeLeft;
    }
}
