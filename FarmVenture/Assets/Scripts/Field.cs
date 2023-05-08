using UnityEngine;

public enum FieldState
{
    Empty,
    Planted,
    Watering,
    Harvestable
}
public class Field : MonoBehaviour
{
    private IFieldState currentState;
    public bool isProcessingAction ;
 
    private void Start()
    {
        SetState(new EmptyState());
    }
   
    public FieldState GetState()
    {
        if (currentState is EmptyState)
        {
            return FieldState.Empty;
        }
        else if (currentState is PlantedState)
        {
            return FieldState.Planted;
        }
        else if (currentState is WateringState)
        {
            return FieldState.Watering;
        }
        else if (currentState is HarvestableState)
        {
            return FieldState.Harvestable;
        }

        return FieldState.Empty; // Varsayýlan durum
    }

    public void SetState(IFieldState state)
    {
        currentState = state;
        currentState.EnterState(this);
    }

    public void Dig()
    {
        currentState.Dig();
      
    }

    public void Plant()
    {
       currentState.Plant();
    }

    public void Water()
    {
       currentState.Water();
    }

    public void Harvest()
    {
        currentState.Harvest();
        SetState(new EmptyState());
    }
    public bool IsProcessingAction()
    {
        return isProcessingAction;
    }
    private CharacterInteraction currentCharacter;

    public void SetCharacterInteraction(CharacterInteraction character)
    {
        currentCharacter = character;
    }

    public void ClearCharacterInteraction()
    {
        if (currentCharacter != null)
        {
            currentCharacter = null;
        }
    }
}
