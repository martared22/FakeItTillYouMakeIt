using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PopupManager : MonoBehaviour
{
    public TextMeshProUGUI text;
    public bool time = false;
    public bool levelCompleted = false;
    public bool failedTries = false;

    void Start()
    {
        bool time = PlayerPrefs.GetInt("timesUp", 0) == 1;
        bool failed = PlayerPrefs.GetInt("failed", 0) == 1;
        bool completed = PlayerPrefs.GetInt("completed", 0) == 1;

        if (time)
        {
            text.text = "Time's Up!";
        } 
        else if (failed) 
        {
            text.text = "You tried too hard and got no far.";
        }
        else if (completed)
        {
            text.text = "Level Completed!";
        }
        Invoke(nameof(LoadNextScene), 3f);
    }

    void LoadNextScene()
    {
        PlayerPrefs.DeleteKey("timesUp");
        PlayerPrefs.Save();

        PlayerPrefs.DeleteKey("completed");
        PlayerPrefs.Save();

        PlayerPrefs.DeleteKey("failed");
        PlayerPrefs.Save();

        SceneManager.LoadScene("lobby");
    }
}
