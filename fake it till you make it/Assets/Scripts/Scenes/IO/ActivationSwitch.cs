using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivationSwitch : MonoBehaviour
{
    private PlayerInputHandler inputHandler;
    public bool canPress;
    public bool activatedSwitch;

    void Start()
    {
        inputHandler = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInputHandler>();
    }

    // Update is called once per frame
    void Update()
    {
        if(canPress && inputHandler.InteractInput) {
            activatedSwitch = !activatedSwitch;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            canPress = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            canPress = false;
        }
    }
}
