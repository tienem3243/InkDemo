using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
public class InputManager : MonoBehaviour
{
    private bool submitPressed=false;
    private bool nextPressed=false;
    private static InputManager instance;
    public bool GetSubmitPresseed(){
        bool res=submitPressed;
        submitPressed=false;
        return res;
    }
     public bool GetNextPresseed(){
        bool res=nextPressed;
        nextPressed=false;
        return res;
    }

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Found another InputManager instance in scene");
        }
        instance = this;
    }
    private void Update() {
      
    }
    public static InputManager getInstance()
    {
        return instance;
    }
    public void SubmitButtonPressed(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            submitPressed = true;
      
        }
        else if(context.canceled)
        {
            submitPressed = false;
        }
    }
     public void NextButtonPressed(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            nextPressed = true;
      
        }
        else if(context.canceled)
        {
            nextPressed = false;
        }
    }
}