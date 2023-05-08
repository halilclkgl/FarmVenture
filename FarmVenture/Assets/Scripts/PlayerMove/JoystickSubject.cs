using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoystickSubject
{
    private Vector2 joystickDirection;
    public event Action<Vector2> OnJoystickInput;

    public void SetJoystickDirection(Vector2 direction)
    {
        joystickDirection = direction;
        NotifyObservers();
    }

    private void NotifyObservers()
    {
        if (OnJoystickInput != null)
        {
            OnJoystickInput.Invoke(joystickDirection);
        }
    }
}
