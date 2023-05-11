using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HarvestingState : IFieldState
{
    public bool deneme = false;
    public void Interact(FieldInteraction fieldInteraction)
    {
        Debug.Log("Hasat al�nd�");

        fieldInteraction.ChangeState(new EmptyState());
        // Tarladaki hasat� alma i�lemleri buraya yaz�l�r
        // if (fieldInteraction.HasHarvest())
        //   {
        //      fieldInteraction.PerformHarvest();
        //  }
    }
}
