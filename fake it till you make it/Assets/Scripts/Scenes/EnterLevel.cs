using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnterLevel : MonoBehaviour
{
    private bool canEnter;
    private string sceneName;

    public PlayerInputHandler InputHandler { get; private set; }

    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (collision.GetComponent<ProgDoor>())
    //    {
    //        sceneName = "Algebra";
    //        Debug.Log(sceneName);
    //        canEnter = true;

    //        Debug.Log("collided");  
    //    }
    //}
    //private void OnTriggerExit2D(Collider2D collision)
    //{
    //    if (collision.GetComponent<ProgDoor>())
    //    {
    //        canEnter = false;

    //        Debug.Log("no collided");
    //    }
    //}

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
