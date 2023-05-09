using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HarvestableState : IFieldState
{
    private CharacterInteraction characterInteraction;
    private float harvestTime = 2f; // Hasat süresi
    private Field field;
    private Harvest harvest;
    public void EnterState(Field field)
    {
        Debug.Log("Tarla hasat için hazýr.");
        this.field = field;
    
    }

    public void Dig()
    {
        Debug.Log("Tarla zaten hasat için hazýr olduðu için kazýlamaz.");
    }

    public void Plant()
    {
        Debug.Log("Tarla zaten hasat için hazýr olduðu için tohum eklenemez.");
    }

    public void Water()
    {
        Debug.Log("Tarla zaten sulandý.");
    }
    public void Harvest()
    {
        Debug.Log("Hasat yapýlýyor...");
        // Hasat iþlemiyle ilgili kodlarý buraya yazýn
        // Ýþlem tamamlandýktan sonra durumu deðiþtirin
       
        field.StartCoroutine(ProcessHarvest());
    }

    private IEnumerator ProcessHarvest()
    {
        Harvest harvest = GameObject.FindGameObjectWithTag("Player").GetComponent<Harvest>();
        characterInteraction = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterInteraction>();
        if (harvest.Stok < 5)
        {
           
            yield return new WaitForSeconds(harvestTime);
            Debug.Log("Hasat tamamlandý.");
            harvest.PerformHarvest();
            field.SetState(new EmptyState());
            characterInteraction.UpdateUIButtons();
        }
        else 
        {
           Debug.Log("aasdasd5asd45a5s4d5as");
            field.SetState(new HarvestableState());
            characterInteraction.UpdateUIButtons();
        }
       
    }
}
