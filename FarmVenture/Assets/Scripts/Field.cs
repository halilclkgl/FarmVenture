using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Field : MonoBehaviour
{
    private bool isEmpty = true; // Tarla bo� mu dolu mu
    private bool isHarvestable = false; // Tarla hasat edilebilir mi
    private bool isWatered = false; // Tarla suland� m�
    private bool isPlanted = false; // Tarla ekildi mi

    private float harvestTime = 2f; // Hasat s�resi
    private float wateringTime = 1f; // Sulama s�resi
    private float plantingTime = 1f; // Ekme s�resi

    private bool isProcessingAction = false; // ��lem s�recinde mi

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            CharacterInteraction character = other.GetComponent<CharacterInteraction>();
            if (character != null)
            {
                character.SetCurrentField(this);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            CharacterInteraction character = other.GetComponent<CharacterInteraction>();
            if (character != null)
            {
                character.ClearCurrentField();
            }
        }
    }

    public void Dig()
    {
        if (!isProcessingAction && isEmpty)
        {
            Debug.Log("Tarla kaz�l�yor...");
            // Kazma i�lemiyle ilgili gerekli kodlar� buraya yaz�n

            isProcessingAction = true;
            isEmpty = false;
            isPlanted = true;
            StartCoroutine(ProcessActionComplete());
        }
    }

    public void Plant()
    {
        if (!isProcessingAction && isPlanted)
        {
            Debug.Log("Tohum ekiliyor...");
            // Ekme i�lemiyle ilgili gerekli kodlar� buraya yaz�n

            isProcessingAction = true;
            isPlanted = false;
            isWatered = true;
            StartCoroutine(ProcessActionComplete());
        }
    }

    public void Water()
    {
        if (!isProcessingAction && isWatered)
        {
            Debug.Log("Tarla sulan�yor...");
            // Sulama i�lemiyle ilgili gerekli kodlar� buraya yaz�n

            isProcessingAction = true;
            isWatered = false;
            isHarvestable = true;
            StartCoroutine(ProcessActionComplete());
        }
    }

    public void Harvest()
    {
        if (!isProcessingAction && isHarvestable)
        {
            Debug.Log("Hasat yap�l�yor...");
            // Hasat i�lemiyle ilgili gerekli kodlar� buraya yaz�n

            isProcessingAction = true;
            isEmpty = true;
            isHarvestable = false;
            StartCoroutine(ProcessActionComplete());
        }
    }

    private IEnumerator ProcessActionComplete()
    {
        yield return new WaitForSeconds(GetCurrentActionTime());
        Debug.Log("��lem tamamland�!");

        isProcessingAction = false;
    }

    private float GetCurrentActionTime()
    {
        if (isWatered)
        {
            return wateringTime;
        }
        else if (isHarvestable)
        {
            return harvestTime;
        }
        else if (isPlanted)
        {
            return plantingTime;
        }

        return 0f; // Varsay�lan olarak 0 s�re d�nd�r�l�r
    }
}