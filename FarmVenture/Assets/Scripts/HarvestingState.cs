using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HarvestingState : IFieldState
{
    public bool deneme = false;
    public void Interact(FieldInteraction fieldInteraction)
    {
        Debug.Log("Hasat alýndý");

        fieldInteraction.ChangeState(new EmptyState());
        // Tarladaki hasatý alma iþlemleri buraya yazýlýr
        // if (fieldInteraction.HasHarvest())
        //   {
        //      fieldInteraction.PerformHarvest();
        //  }
    }
}
