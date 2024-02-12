using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OptionsController : MonoBehaviour
{
    private string previousScene;
    public void CloseOptionsMenu()
    {
        previousScene = GameManager.Instance.previousScene;
        SceneManager.LoadScene(previousScene);
    }
}
