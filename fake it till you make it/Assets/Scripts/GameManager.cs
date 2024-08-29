using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using static Cinemachine.DocumentationSortingAttribute;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public string previousScene;
    public List<Level> levels = new List<Level>();

    public bool isTutorial = true;
    public bool isResited = false; 

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

    public float lastPlayerPosition;

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

        AddLevel("Algebra");
        AddLevel("Calcul");
        AddLevel("IO");
        AddLevel("Electro");
        AddLevel("Prog");
        AddLevel("PiC");
        AddLevel("DiU");
        AddLevel("BiE");
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
        SceneManager.LoadScene("LoadingScene");
        yield return new WaitForSeconds(5f);
        LoadTutorialScene();
        
    }
    void LoadMainScene()
    {
        SceneManager.LoadScene("MainMenu");
    }

    // POSAR SCENE DE TUTORIAL SI EL FAIG
    void LoadTutorialScene()
    {
        SceneManager.LoadScene("Tutorial");
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
            if(isCompleted)
            {
                CompleteLevel(levelName);
            }
        }
        else
        {
            levelCompletionStatus.Add(levelName, isCompleted);
        }
    }

    public void CompleteLevel(string levelName)
    {
        foreach (Level level in levels)
        {
            if (level.name == levelName)
            {
                switch (levelName)
                {
                    case "Algebra":
                        level.starsEarned = algebraPoints;
                        break;
                    case "Calcul":
                        level.starsEarned = calculPoints;
                        break;
                    case "IO":
                        level.starsEarned = ioPoints;
                        break;
                    case "Electro":
                        level.starsEarned = electroPoints;
                        break;
                    case "Prog":
                        level.starsEarned = progPoints;
                        break;
                    case "PiC":
                        level.starsEarned = picPoints;
                        break;
                    case "DiU":
                        level.starsEarned = diuPoints;
                        break;
                    case "BiE":
                        level.starsEarned = biePoints;
                        break;
                    default:
                        Debug.LogWarning("Invalid level name: " + levelName);
                        return;
                }
                level.levelVisited = true;
                level.CheckLevelFailed();
                break;
            }
        }
    }
    public bool AreAllLevelsVisited()
    {
        foreach (Level level in levels)
        {
            if (!level.levelVisited)
            {
                return false;
            }
        }
        return true;
    }

    public bool AreAllLevelsNotFailed()
    {
        foreach (Level level in levels)
        {
            if (level.levelFailed)
            {
                return false;
            }
        }
        return true;
    }

    public bool GetLevelCompletionStatus(string levelName)
    {
        if (levelCompletionStatus.TryGetValue(levelName, out bool isCompleted))
        {
            return isCompleted;
        }
        else
        {
            return false;
        }
    }

    public void SaveCurrentPage(int currentPage)
    {
        PlayerPrefs.SetInt("CurrentPage", currentPage);
        PlayerPrefs.Save();
    }

    public int LoadCurrentPage()
    {
        return PlayerPrefs.GetInt("CurrentPage", 0);
    }

    public void SavePlayerPosition(float position)
    {
        lastPlayerPosition = position;
    }

    public void AddLevel(string levelName)
    {
        Level newLevel = new Level(levelName);
        levels.Add(newLevel);
        levelCompletionStatus[levelName] = false;
    }

    public void ResitLevel()
    {
        foreach (Level level in levels)
        {
            if (level.levelFailed)
            {
                level.levelVisited = false;
                PlayerPrefs.DeleteKey("LevelVisited_" + level.name);
                SetLevelCompletionStatus(level.name, false);
                level.levelFailed = false;
            }
        }
    }
}
