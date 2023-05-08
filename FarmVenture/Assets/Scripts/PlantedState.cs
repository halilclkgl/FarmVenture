using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlantedState : IFieldState
{
    private CharacterInteraction characterInteraction;
    private float plantedTime = 1f; // ekim s�resi
    private Field field;
    public void EnterState(Field field)
    {
        Debug.Log("Tarlaya tohum ekimi i�in haz�r.");
        this.field = field;
       
    }

    public void Dig()
    {
        Debug.Log("Tarla zaten ekili oldu�u i�in kaz�lamaz.");
    }

    public void Plant()
    {
        Debug.Log("Tarla ekiliyor.");
        // Sulama i�lemiyle ilgili kodlar� buraya yaz�n
        // ��lem tamamland�ktan sonra durumu de�i�tirin
        field.StartCoroutine(ProcessPlanted());
    }

    public void Water()
    {
        Debug.Log("Tarla yeni ekildi�i i�in sulanamaz");
       
       
    }

    public void Harvest()
    {
        Debug.Log("Tarla hen�z hasat edilemez.");
    }
    private IEnumerator ProcessPlanted()
    {
        yield return new WaitForSeconds(plantedTime);
        Debug.Log("Ekim tamamland�.");
        characterInteraction = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterInteraction>();
        field.SetState(new WateringState());
        characterInteraction.UpdateUIButtons();
       
    }
}
