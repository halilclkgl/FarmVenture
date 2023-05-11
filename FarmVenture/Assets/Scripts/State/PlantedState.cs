using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlantedState : IFieldState
{
    public void Interact(FieldInteraction fieldInteraction)
    {
        Debug.Log("Tarla ekildi.");
        // Sulama işlemini gerçekleştirme kodları
        // ...
        fieldInteraction.ChangeState(new WateringState());
    }
}
