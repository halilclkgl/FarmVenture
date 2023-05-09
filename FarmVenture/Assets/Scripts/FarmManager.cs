using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FarmManager : MonoBehaviour
{

    [SerializeField]private bool isPurchased = false; // Tarlanýn satýn alýnýp alýnmadýðýný tutan bool deðeri
    public int fieldCost = 50; // Tarla maliyeti
    public bool IsPurchased
    {

        get { return isPurchased; }

        set { isPurchased = value; }
    }

}
