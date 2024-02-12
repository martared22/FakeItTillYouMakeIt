using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartupManager : MonoBehaviour
{
    void Start()
    {
        SceneManager.LoadScene("Managers", LoadSceneMode.Additive);
    }
}