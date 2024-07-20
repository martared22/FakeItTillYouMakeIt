using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelFinalTrigger : MonoBehaviour
{
    public GameManager gameManager;
    public bool isLevelFinal = false;

    private void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            gameManager.diuPoints = 5;

            Debug.Log("Quiz completed!");

            PlayerPrefs.SetInt("completed", true ? 1 : 0);
            PlayerPrefs.Save();

            SceneManager.LoadScene("PopupScene");
        }
    }
}
