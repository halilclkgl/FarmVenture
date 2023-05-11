using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;
using UnityEngine.UI;

public class CharacterInteraction : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Field"))
        {
         
            FieldInteraction fieldInteraction = other.gameObject.GetComponent<FieldInteraction>();
            fieldInteraction?.Interact();
        }
    }

}