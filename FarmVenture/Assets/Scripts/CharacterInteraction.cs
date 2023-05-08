using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterInteraction : MonoBehaviour
{
    private Field currentField; // Etkileþime giren tarla objesi

    private void Update()
    {
        if (currentField != null)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                currentField.Dig();
            }
            else if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                currentField.Plant();
            }
            else if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                currentField.Water();
            }
            else if (Input.GetKeyDown(KeyCode.Alpha4))
            {
                currentField.Harvest();
            }
        }
    }

    public void SetCurrentField(Field field)
    {
        currentField = field;
    }

    public void ClearCurrentField()
    {
        currentField = null;
    }
}
