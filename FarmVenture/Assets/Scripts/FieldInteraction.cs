
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.UI;

public class FieldInteraction : MonoBehaviour
{
    public IFieldState currentState;
    private bool isInteracting;
    private float interactionDuration = 2f;
    public GameObject canvasObje;
    public ProgressBar progressBar;
    public Harvest harvest;

    [SerializeField] private Field field;
    public Image[] image;
    private void Start()
    {
        // Ba�lang�� durumunu ayarla
        currentState = new EmptyState();
        progressBar.ResetProgressBar();
        // farmManager = gameObject.GetComponent<FarmManager>();
    }

    public void PurchaseField()
    {
        // field.SetPurchasedStatus(true);
        // Di�er sat�n alma i�lemleri ve g�ncellemeler
    }
    public void Interact()
    {

        // E�er etkile�im devam ediyorsa ge�ersiz k�l
        if (isInteracting)
        {
            // Debug.Log("i�lem devam ediyor");
            return;
        }
        if (currentState is HarvestingState)
        {
            if (harvest.harvestList.Count < 20)
            {
                harvest.PerformHarvest(1);
            }
            else
            {
                return;
            }
        }
        if (field.isPurchased)
        {
            currentState.Interact(this);
        }
      
    }

    public void ChangeState(IFieldState newState)
    {
        if (field.isPurchased)
        {

            // Durum de�i�ti�inde etkile�im s�resini ba�lat
            StartCoroutine(StartInteractionTimer());
            StartCoroutine(InteractionTimer());
            currentState = newState;
        }

    }

    private IEnumerator StartInteractionTimer()
    {

        canvasObje.SetActive(true);

        float elapsedTime = 0f;
        while (elapsedTime < interactionDuration)
        {
            if (currentState is EmptyState)
            {
                float progress = 2f / interactionDuration;
                progressBar.UpdateFillAmount(progress);
                yield return null;
            }
            else
            {
                elapsedTime += Time.deltaTime;
                float progress = elapsedTime / interactionDuration;

                // �lerleme �ubu�unun doluluk de�erini g�ncelle
                progressBar.UpdateFillAmount(progress);

                yield return null;
            }

        }


    }
    private IEnumerator InteractionTimer()
    {
        isInteracting = true;
        if (currentState != null)
        {
            image[0].gameObject.SetActive(false);
            image[1].gameObject.SetActive(false);
            image[2].gameObject.SetActive(false);
            image[3].gameObject.SetActive(false);
            image[4].gameObject.SetActive(false);

            if (currentState is EmptyState)
            {
                image[0].gameObject.SetActive(true);
               
            }
            else if (currentState is PlantedState)
            {
                image[1].gameObject.SetActive(true);
            }
            else if (currentState is WateringState)
            {
                image[2].gameObject.SetActive(true);
            }
            else if (currentState is HarvestableState)
            {
                image[3].gameObject.SetActive(true);
            }
            else if (currentState is HarvestingState)
            {
                image[4].gameObject.SetActive(true);
            }
        }
        if (currentState is HarvestingState)
        {
            yield return new WaitForSeconds(0.2f);
            isInteracting = false;
        }
        else
        {
            yield return new WaitForSeconds(interactionDuration);
            isInteracting = false;
        }


    }
}

