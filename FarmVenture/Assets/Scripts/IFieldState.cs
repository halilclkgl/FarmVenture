using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IFieldState
{
    void EnterState(Field field);
    void Dig();
    void Plant();
    void Water();
    void Harvest();
}
