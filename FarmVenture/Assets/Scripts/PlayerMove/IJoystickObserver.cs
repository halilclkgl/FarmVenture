using UnityEngine;
using System;

// Observer Tasar�m Kal�b�
public interface IJoystickObserver
{
    void OnJoystickInput(Vector2 direction);
}