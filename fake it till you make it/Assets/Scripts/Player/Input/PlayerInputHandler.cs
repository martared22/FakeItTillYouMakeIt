using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputHandler : MonoBehaviour
{
    [SerializeField]
    private PlayerInput playerInput;

    public Vector2 RawMovementInput {get; private set;}
    public int NormInputX { get; private set;}
    public int NormInputY { get; private set;}
    public bool JumpInput { get; private set;}
    public bool InteractInput { get; private set;}
    public bool PauseInput { get; private set; }
    public bool DocumentationInput { get; private set; }

    [SerializeField]
    private float inputHoldTime = 0.2f;

    private float jumpInputStartTime;

    private void Update()
    {
        CheckJumpInputHoldTime();
    }

    public void OnSwitchMap(string actionMap)
    {
        playerInput.SwitchCurrentActionMap(actionMap);
    }

    public void OnMoveInput(InputAction.CallbackContext context)
    {
        RawMovementInput = context.ReadValue<Vector2>();
        NormInputX = (int)(RawMovementInput * Vector2.right).normalized.x;
        NormInputY = (int)(RawMovementInput * Vector2.up).normalized.y;
    }

    public void OnJumpInput(InputAction.CallbackContext context)
    {   
        if (context.started)
        {
            JumpInput = true;
            jumpInputStartTime = Time.time;
        }    
    }

    private void CheckJumpInputHoldTime()
    {
        if (Time.time >= jumpInputStartTime + inputHoldTime)
        {
            JumpInput = false;
        }
    }

    public void UseJumpInput() => JumpInput = false;

    public void OnInteractInput(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            Debug.Log("F pressed");
            InteractInput = true;
        } 
        else if (context.canceled)
        {
            Debug.Log("F Depressed");
            InteractInput = false;
        }
    }

    public void PauseMenuInput(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Debug.Log("pause pressed");
            PauseInput = true;
          
        }
        else if (context.canceled)
        {
            Debug.Log("pause Depressed");
            PauseInput = false;
         
        }
    }

    public void DocumentationInputAction(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Debug.Log("documentation pressed");
            DocumentationInput = true;
        }
        else if (context.canceled)
        {
            Debug.Log("documentation Depressed");
            DocumentationInput = false;
        }
    }
}
