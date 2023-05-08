using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmptyState : IFieldState
{
    private CharacterInteraction characterInteraction;
    private float emptyTime = 1f; // Hasat süresi
    private Field field;
    public void EnterState(Field field)
    {
        Debug.Log("Tarla boþ.");
        this.field= field;

    }

    public void Dig()
    {
        
            Debug.Log("Tarla kazýlýyor...");
           
            field.StartCoroutine(ProcessEmpty());
        
    }

    public void Plant()
    {
        Debug.Log("Tarla boþ olduðu için tohum eklenemez.");
    }

    public void Water()
    {
        Debug.Log("Tarla boþ olduðu için sulanamaz.");
    }

    public void Harvest()
    {
        Debug.Log("Tarla boþ olduðu için hasat yapýlamaz.");
    }
    private IEnumerator ProcessEmpty()
    {
        yield return new WaitForSeconds(emptyTime);
           Debug.Log("Kazým tamamlandý.");
        characterInteraction = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterInteraction>();

        field.SetState(new PlantedState());
        characterInteraction.UpdateUIButtons();
     
    }
}

