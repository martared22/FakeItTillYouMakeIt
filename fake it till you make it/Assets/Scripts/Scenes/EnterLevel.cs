using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnterLevel : MonoBehaviour
{
    private bool canEnter;
    private string sceneName;

    public PlayerInputHandler InputHandler { get; private set; }

    private void Start()
    {
        InputHandler = GetComponent<PlayerInputHandler>();
    }
    
    private void Update()
    {
        if (canEnter && InputHandler.InteractInput)
        {
            Debug.Log("new scene");
            SceneManager.LoadScene("Algebra");
        }
    }
    
}
