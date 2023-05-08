using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Field : MonoBehaviour
{
    private bool isEmpty = true; // Tarla boþ mu dolu mu
    private bool isHarvestable = false; // Tarla hasat edilebilir mi
    private bool isWatered = false; // Tarla sulandý mý
    private bool isPlanted = false; // Tarla ekildi mi

    private float harvestTime = 2f; // Hasat süresi
    private float wateringTime = 1f; // Sulama süresi
    private float plantingTime = 1f; // Ekme süresi

    private bool isProcessingAction = false; // Ýþlem sürecinde mi

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
            Debug.Log("Tarla kazýlýyor...");
            // Kazma iþlemiyle ilgili gerekli kodlarý buraya yazýn

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
            // Ekme iþlemiyle ilgili gerekli kodlarý buraya yazýn

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
            Debug.Log("Tarla sulanýyor...");
            // Sulama iþlemiyle ilgili gerekli kodlarý buraya yazýn

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
            Debug.Log("Hasat yapýlýyor...");
            // Hasat iþlemiyle ilgili gerekli kodlarý buraya yazýn

            isProcessingAction = true;
            isEmpty = true;
            isHarvestable = false;
            StartCoroutine(ProcessActionComplete());
        }
    }

    private IEnumerator ProcessActionComplete()
    {
        yield return new WaitForSeconds(GetCurrentActionTime());
        Debug.Log("Ýþlem tamamlandý!");

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

        return 0f; // Varsayýlan olarak 0 süre döndürülür
    }
}