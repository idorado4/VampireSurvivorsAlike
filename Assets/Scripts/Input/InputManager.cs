using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour, IInputSystem
{
    public static InputManager Instance { get; private set; }
    private DefaultInputActions defaultInputActions;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    private void Start()
    {
        defaultInputActions = new DefaultInputActions();
        defaultInputActions.Enable();
    }

    public Vector2 GetMovement()
    {
        return defaultInputActions.Player.Move.ReadValue<Vector2>();
    }

    public bool Test()
    {
        return defaultInputActions.Player.Test.triggered;
    }
}