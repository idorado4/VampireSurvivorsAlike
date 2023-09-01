using UnityEngine;

public class UnityInputAdapter : IInputSystem
{
    private readonly DefaultInputActions _defaultInputActions;

    public UnityInputAdapter()
    {
        _defaultInputActions = new DefaultInputActions();
        _defaultInputActions.Enable();
    }

    public Vector2 GetDirection()
    {
        return _defaultInputActions.Player.Move.ReadValue<Vector2>();
    }
}