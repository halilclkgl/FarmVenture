using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WateringState : IFieldState
{
    public void Interact(FieldInteraction fieldInteraction)
    {
        Debug.Log("Tarla suland�");
        // Hasat i�lemini ger�ekle�tirme kodlar�
        // ...
        fieldInteraction.ChangeState(new HarvestableState());
    }
}
