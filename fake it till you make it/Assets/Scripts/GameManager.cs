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
    public Dictionary<string, bool> levelCompletionStatus = new Dictionary<string, bool>();

    public int algebraPoints = 0;
    public int calculPoints = 0;
    public int ioPoints = 0;
    public int electroPoints = 0;
    public int progPoints = 0;
    public int picPoints = 0;
    public int diuPoints = 0;
    public int biePoints = 0;

    public int totalPoints = 0;

    private void Awake()
    {
        PlayerPrefs.DeleteAll();
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
    
    public int CalculateTotalPoints () 
    {
        totalPoints = algebraPoints + calculPoints + ioPoints + electroPoints + progPoints + picPoints + diuPoints + biePoints;
        return totalPoints;
    }

    // PREPARAT PER FICAR TUTORIAL SI CAL
    void InitializeGame()
    {
        if (IsFirstTime())
        {
            SetFirstTimeFlag(false);
            //LoadTutorialScene();
            LoadLoadingScene();
        }
        else
        {
            LoadLoadingScene();
        }
    }

    void LoadLoadingScene()
    {
        StartCoroutine(PlayLoadingScene());
    }
    IEnumerator PlayLoadingScene()
    {
        // Load the loading scene
        SceneManager.LoadScene("LoadingScene");

        // Wait for 5 seconds
        yield return new WaitForSeconds(5f);

        // Load the main menu scene
        LoadMainScene();
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

    public void SetLevelCompletionStatus(string levelName, bool isCompleted)
    {
        if (levelCompletionStatus.ContainsKey(levelName))
        {
            levelCompletionStatus[levelName] = isCompleted;
        }
        else
        {
            levelCompletionStatus.Add(levelName, isCompleted);
        }
    }
}
