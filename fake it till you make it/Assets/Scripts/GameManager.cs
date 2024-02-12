using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public string previousScene;

    private const string FirstTimeKey = "FirstTime";

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    void Start()
    {
        InitializeGame();
    }

    // PREPARAT PER FICAR TUTORIAL SI CAL
    void InitializeGame()
    {
        if (IsFirstTime())
        {
            SetFirstTimeFlag(false);
            //LoadTutorialScene();
            LoadMainScene();
        }
        else
        {
            LoadMainScene();
        }
    }

    void LoadMainScene()
    {
        SceneManager.LoadScene("MainMenu");
    }

    // POSAR SCENE DE TUTORIAL SI EL FAIG
    void LoadTutorialScene()
    {
        //SceneManager.LoadScene("Tutorial");
    }

    bool IsFirstTime()
    {
        return !PlayerPrefs.HasKey(FirstTimeKey);
    }

    void SetFirstTimeFlag(bool value)
    {
        PlayerPrefs.SetInt(FirstTimeKey, value ? 1 : 0);
        PlayerPrefs.Save();
    }

    public void ShowOptionsMenu()
    {
        previousScene = SceneManager.GetActiveScene().name;
        Debug.Log(previousScene);
        SceneManager.LoadScene("OptionsMenu");
    }
}
