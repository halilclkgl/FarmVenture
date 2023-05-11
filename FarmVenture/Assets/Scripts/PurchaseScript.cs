using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PurchaseScript : MonoBehaviour
{
    private FarmManager farmManager;
    public MoneyManager moneyManager;
    public Button purchaseButton;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Field"))
        {
            farmManager = other.GetComponent<FarmManager>();

            if (farmManager != null && !farmManager.IsPurchased)
            {
                ButtonInTrue();
             //   Debug.Log("Tarla satýn alýndý!");
            }
            else
            {
              //  Debug.Log("Tarla zaten satýn alýnmýþ!");
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Field"))
        {
            farmManager = other.GetComponent<FarmManager>();
            ButtonInFalse();
        }
    }

    void ButtonInTrue()
    {
        purchaseButton.gameObject.SetActive(true);
    }

    void ButtonInFalse()
    {
        purchaseButton.gameObject.SetActive(false);
    }

    public void BuyField()
    {
        if (farmManager != null && moneyManager.money >= farmManager.fieldCost)
        {
            moneyManager.money -= farmManager.fieldCost;
            farmManager.IsPurchased = true;
          //  Debug.Log("Tarla satýn alýndý!");
            ButtonInFalse();
        }
        else
        {
          //  Debug.Log("Yeterli para yok!");
        }
    }
}
