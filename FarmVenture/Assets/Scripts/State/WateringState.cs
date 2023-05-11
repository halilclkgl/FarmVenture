using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WateringState : IFieldState
{
    public void Interact(FieldInteraction fieldInteraction)
    {
        Debug.Log("Tarla sulandý");
        // Hasat iþlemini gerçekleþtirme kodlarý
        // ...
        fieldInteraction.ChangeState(new HarvestableState());
    }
}
