using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HarvestableState : IFieldState
{
    public void Interact(FieldInteraction fieldInteraction)
    {
        Debug.Log("Hasat yapýldý.");
        // Kazma iþlemini gerçekleþtirme kodlarý
        // ...
        fieldInteraction.ChangeState(new HarvestingState());
      
    }
}
