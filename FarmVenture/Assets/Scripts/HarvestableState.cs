using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HarvestableState : IFieldState
{
    private CharacterInteraction characterInteraction;
    private float harvestTime = 2f; // Hasat s�resi
    private Field field;

    public void EnterState(Field field)
    {
        Debug.Log("Tarla hasat i�in haz�r.");
        this.field = field;
    
    }

    public void Dig()
    {
        Debug.Log("Tarla zaten hasat i�in haz�r oldu�u i�in kaz�lamaz.");
    }

    public void Plant()
    {
        Debug.Log("Tarla zaten hasat i�in haz�r oldu�u i�in tohum eklenemez.");
    }

    public void Water()
    {
        Debug.Log("Tarla zaten suland�.");
    }
    public void Harvest()
    {
        Debug.Log("Hasat yap�l�yor...");
        // Hasat i�lemiyle ilgili kodlar� buraya yaz�n
        // ��lem tamamland�ktan sonra durumu de�i�tirin
       
        field.StartCoroutine(ProcessHarvest());
    }

    private IEnumerator ProcessHarvest()
    {
        Harvest harvest = GameObject.FindGameObjectWithTag("Player").GetComponent<Harvest>();
        if (harvest.Stok<5)
        {
            yield return new WaitForSeconds(harvestTime);
            Debug.Log("Hasat tamamland�.");
            characterInteraction = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterInteraction>();

            harvest.PerformHarvest();
            field.SetState(new EmptyState());
            characterInteraction.UpdateUIButtons();
        }
         field.SetState(new HarvestableState());
        characterInteraction.UpdateUIButtons();
    }
}
