using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level2Trigger : MonoBehaviour
{
    public GameManager gameManager;
    public bool isLevel2 = false;

    private void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("Level 2 Triggered");
            GameObject.Find("Platform Generator").GetComponent<PlatformGenerator>().GenerateAdditionalPlatforms();
            gameManager.diuPoints = 3;
        }
    }
}
