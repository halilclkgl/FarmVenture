using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmptyState : IFieldState
{
    public void Interact(FieldInteraction fieldInteraction)
    {
        Debug.Log("Tarla kaz�ld�.");
        // Ekme i�lemini ger�ekle�tirme kodlar�
        // ...

        fieldInteraction.ChangeState(new PlantedState());
    }
}

