using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoystickController : MonoBehaviour
{
    public Joystick joystick;
    private JoystickSubject joystickSubject;

    private void Awake()
    {
        joystickSubject = new JoystickSubject();
    }

    private void OnEnable()
    {
        joystickSubject.OnJoystickInput += NotifyJoystickInput;
    }

    private void OnDisable()
    {
        joystickSubject.OnJoystickInput -= NotifyJoystickInput;
    }

    private void NotifyJoystickInput(Vector2 direction)
    {
        // Observer'lara joystick konumunu ileten fonksiyon
        foreach (IJoystickObserver observer in GetComponents<IJoystickObserver>())
        {
            observer.OnJoystickInput(direction);
        }
    }

    private void Update()
    {
        joystickSubject.SetJoystickDirection(new Vector2(joystick.Horizontal, joystick.Vertical));
    }
}
