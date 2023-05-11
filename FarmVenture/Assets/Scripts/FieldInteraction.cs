
 using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Playables;

public class FieldInteraction : MonoBehaviour
{
    public IFieldState currentState;
    private bool isInteracting;
    private float interactionDuration = 1f;
    public GameObject canvasObje;
    public ProgressBar progressBar;
    public Harvest harvest;
    [SerializeField]private FarmManager farmManager;
    private void Start()
    {
        // Ba�lang�� durumunu ayarla
        currentState = new EmptyState();
        progressBar.ResetProgressBar();
        farmManager = gameObject.GetComponent<FarmManager>();
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
            if (harvest.harvestList.Count < 5)
            {
                harvest.PerformHarvest();
            }
            else 
            {
                return;
            }
        }
        currentState.Interact(this);
    }

    public void ChangeState(IFieldState newState)
    {
        if (farmManager.IsPurchased)
        {
            currentState = newState;
            // Durum de�i�ti�inde etkile�im s�resini ba�lat
            StartCoroutine(StartInteractionTimer());
            StartCoroutine(InteractionTimer());
        }   
        
     }

    private IEnumerator StartInteractionTimer()
    {
     
        canvasObje.SetActive(true);
        float elapsedTime = 0f;
        while (elapsedTime < interactionDuration)
        {
            elapsedTime += Time.deltaTime;
            float progress = elapsedTime / interactionDuration;

            // �lerleme �ubu�unun doluluk de�erini g�ncelle
            progressBar.UpdateFillAmount(progress);

            yield return null;
        }

      
    }
    private IEnumerator InteractionTimer()
    {
        isInteracting = true;

        yield return new WaitForSeconds(interactionDuration);
        isInteracting = false;
    }
}

