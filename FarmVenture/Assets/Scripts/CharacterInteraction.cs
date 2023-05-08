using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;
using UnityEngine.UI;

public class CharacterInteraction : MonoBehaviour
{

    public Button digButton;
    public Button plantButton;
    public Button harvestButton;
    public Button waterButton;
    public GameObject panel;
    private Field currentField;
    private FarmManager farmManager;
   
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Field"))
        {
            Field field = other.GetComponent<Field>();
           farmManager = other.gameObject.GetComponent<FarmManager>();
            if (field != null && farmManager != null && farmManager.isPurchased)
            {
                currentField = field;
                UpdateUIButtons();
            }
        }   
    }

        private void OnTriggerExit(Collider other)
    {
   
        if (other.CompareTag("Field") )
        {
            currentField = null;
            ResetUIButtons();
        }
    }

    public void UpdateUIButtons()
    {
        if (currentField == null)
        {
            ResetUIButtons();
            return;
        }
      
        if (currentField.GetState() == FieldState.Empty)
        {
            panel.SetActive(true);
            digButton.gameObject.SetActive(true);
            plantButton.gameObject.SetActive(false);
            harvestButton.gameObject.SetActive(false);
            waterButton.gameObject.SetActive(false);
        }
        else if (currentField.GetState() == FieldState.Planted)
        {
            panel.SetActive(true);
            digButton.gameObject.SetActive(false);
            plantButton.gameObject.SetActive(true);
            harvestButton.gameObject.SetActive(false);
            waterButton.gameObject.SetActive(false);
        }
        else if (currentField.GetState() == FieldState.Watering)
        {
            panel.SetActive(true);
            digButton.gameObject.SetActive(false);
            plantButton.gameObject.SetActive(false);
            harvestButton.gameObject.SetActive(true);
            waterButton.gameObject.SetActive(false);
        }
        else if (currentField.GetState() == FieldState.Harvestable)
        {
            panel.SetActive(true);
            digButton.gameObject.SetActive(false);
            plantButton.gameObject.SetActive(false);
            harvestButton.gameObject.SetActive(false);
            waterButton.gameObject.SetActive(true);
        }
    }

    private void ResetUIButtons()
    {
        panel.SetActive(false);
        digButton.gameObject.SetActive(false);
        plantButton.gameObject.SetActive(false);
        harvestButton.gameObject.SetActive(false);
        waterButton.gameObject.SetActive(false);
    }

    public void WaterButtonClicked()
    {
        if (currentField != null && currentField.GetState() == FieldState.Watering)
        {
            currentField.Water();
            UpdateUIButtons();
        }
    }
    public void DigButtonClicked()
    {
        if (currentField != null && currentField.GetState() == FieldState.Empty)
        {
            currentField.Dig();
            UpdateUIButtons();
        }
    }
    public void PlantButtonClicked()
    {
        if (currentField != null && currentField.GetState() == FieldState.Planted)
        {
            currentField.Plant();
            UpdateUIButtons();
        }
    }

    public void HarvestButtonClicked()
    {
        if (currentField != null && currentField.GetState() == FieldState.Harvestable)
        {
            currentField.Harvest();
            UpdateUIButtons();
        }
    }
    
}