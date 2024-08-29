using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelsManager : MonoBehaviour
{
    GameManager gameManager;

    void Start()
    {
        gameManager = FindObjectOfType<GameManager>(); 
    }

    private void Update()
    {
        bool allLevelsVisited = gameManager.AreAllLevelsVisited();
        if (allLevelsVisited)
        {
            Debug.Log("All levels have been visited.");
            SceneManager.LoadScene("Tutorial");
        }
    }
}
