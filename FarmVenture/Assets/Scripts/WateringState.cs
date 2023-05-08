using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WateringState : IFieldState
{
    private CharacterInteraction characterInteraction;
    private float plantedTime = 1f; // Sulama s�resi
    private Field field;
    public void EnterState(Field field)
    {
        Debug.Log("Tarla sulama i�in haz�r.");
        this.field = field;
    
    }

    public void Dig()
    {
        Debug.Log("Tarla kaz�lamaz.");
    }

    public void Plant()
    {
        Debug.Log("Tarla zaten ekili.");
    }

    public void Water()
    {
        Debug.Log("Tarla sulan�yor...");
        // Sulama i�lemiyle ilgili kodlar� buraya yaz�n

        // ��lem tamamland�ktan sonra durumu de�i�tirin
        field.StartCoroutine(ProcessWatering());
    }

    public void Harvest()
    {
        Debug.Log("Tarla hen�z hasat edilemez.");
    }
    private IEnumerator ProcessWatering()
    {
        yield return new WaitForSeconds(plantedTime);
        Debug.Log("Sulama tamamland�.");
        characterInteraction = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterInteraction>();
        field.SetState(new HarvestableState());
        characterInteraction.UpdateUIButtons();
      
    }
}
