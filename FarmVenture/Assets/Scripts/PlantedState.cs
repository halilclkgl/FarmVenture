using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlantedState : IFieldState
{
    private CharacterInteraction characterInteraction;
    private float plantedTime = 1f; // ekim süresi
    private Field field;
    public void EnterState(Field field)
    {
        Debug.Log("Tarlaya tohum ekimi için hazýr.");
        this.field = field;
       
    }

    public void Dig()
    {
        Debug.Log("Tarla zaten ekili olduðu için kazýlamaz.");
    }

    public void Plant()
    {
        Debug.Log("Tarla ekiliyor.");
        // Sulama iþlemiyle ilgili kodlarý buraya yazýn
        // Ýþlem tamamlandýktan sonra durumu deðiþtirin
        field.StartCoroutine(ProcessPlanted());
    }

    public void Water()
    {
        Debug.Log("Tarla yeni ekildiði için sulanamaz");
       
       
    }

    public void Harvest()
    {
        Debug.Log("Tarla henüz hasat edilemez.");
    }
    private IEnumerator ProcessPlanted()
    {
        yield return new WaitForSeconds(plantedTime);
        Debug.Log("Ekim tamamlandý.");
        characterInteraction = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterInteraction>();
        field.SetState(new WateringState());
        characterInteraction.UpdateUIButtons();
       
    }
}
