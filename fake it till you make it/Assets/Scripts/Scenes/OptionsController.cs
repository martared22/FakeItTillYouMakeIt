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

    //public void Fullscene(bool is_fullscene)
    //{
    //    Screen.fullScreen = is_fullscene;
    //}
}
