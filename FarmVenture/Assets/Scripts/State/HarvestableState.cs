using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HarvestableState : IFieldState
{
    public void Interact(FieldInteraction fieldInteraction)
    {
        Debug.Log("Hasat yap�ld�.");
        // Kazma i�lemini ger�ekle�tirme kodlar�
        // ...
        fieldInteraction.ChangeState(new HarvestingState());
      
    }
}
