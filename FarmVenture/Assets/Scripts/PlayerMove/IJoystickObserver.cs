using UnityEngine;
using System;

// Observer Tasarým Kalýbý
public interface IJoystickObserver
{
    void OnJoystickInput(Vector2 direction);
}