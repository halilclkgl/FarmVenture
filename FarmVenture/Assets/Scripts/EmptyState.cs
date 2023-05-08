using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmptyState : IFieldState
{
    private CharacterInteraction characterInteraction;
    private float emptyTime = 1f; // Hasat s�resi
    private Field field;
    public void EnterState(Field field)
    {
        Debug.Log("Tarla bo�.");
        this.field= field;

    }

    public void Dig()
    {
        
            Debug.Log("Tarla kaz�l�yor...");
           
            field.StartCoroutine(ProcessEmpty());
        
    }

    public void Plant()
    {
        Debug.Log("Tarla bo� oldu�u i�in tohum eklenemez.");
    }

    public void Water()
    {
        Debug.Log("Tarla bo� oldu�u i�in sulanamaz.");
    }

    public void Harvest()
    {
        Debug.Log("Tarla bo� oldu�u i�in hasat yap�lamaz.");
    }
    private IEnumerator ProcessEmpty()
    {
        yield return new WaitForSeconds(emptyTime);
           Debug.Log("Kaz�m tamamland�.");
        characterInteraction = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterInteraction>();

        field.SetState(new PlantedState());
        characterInteraction.UpdateUIButtons();
     
    }
}

