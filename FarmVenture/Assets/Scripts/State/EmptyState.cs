using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmptyState : IFieldState
{
    public void Interact(FieldInteraction fieldInteraction)
    {
        Debug.Log("Tarla kazýldý.");
        // Ekme iþlemini gerçekleþtirme kodlarý
        // ...

        fieldInteraction.ChangeState(new PlantedState());
    }
}

