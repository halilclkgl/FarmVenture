using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Field : MonoBehaviour
{
    public string fieldID; // Tarla benzersiz bir tan�mlay�c�ya sahip olmal�
    public bool isPurchased = false;

    private void Start()
    {
       // PlayerPrefs.DeleteKey(fieldID);
        int purchasedValue = PlayerPrefs.GetInt(fieldID);
        isPurchased = purchasedValue == 1;
    }
    public void SavePurchaseStatus()
    {

        isPurchased = true;
        // Sat�n alma durumunu PlayerPrefs'e kaydet
        PlayerPrefs.SetInt(fieldID, isPurchased ? 1 : 0);
    }
}
