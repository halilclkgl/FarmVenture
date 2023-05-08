using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WateringState : IFieldState
{
    private CharacterInteraction characterInteraction;
    private float plantedTime = 1f; // Sulama süresi
    private Field field;
    public void EnterState(Field field)
    {
        Debug.Log("Tarla sulama için hazýr.");
        this.field = field;
    
    }

    public void Dig()
    {
        Debug.Log("Tarla kazýlamaz.");
    }

    public void Plant()
    {
        Debug.Log("Tarla zaten ekili.");
    }

    public void Water()
    {
        Debug.Log("Tarla sulanýyor...");
        // Sulama iþlemiyle ilgili kodlarý buraya yazýn

        // Ýþlem tamamlandýktan sonra durumu deðiþtirin
        field.StartCoroutine(ProcessWatering());
    }

    public void Harvest()
    {
        Debug.Log("Tarla henüz hasat edilemez.");
    }
    private IEnumerator ProcessWatering()
    {
        yield return new WaitForSeconds(plantedTime);
        Debug.Log("Sulama tamamlandý.");
        characterInteraction = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterInteraction>();
        field.SetState(new HarvestableState());
        characterInteraction.UpdateUIButtons();
      
    }
}
