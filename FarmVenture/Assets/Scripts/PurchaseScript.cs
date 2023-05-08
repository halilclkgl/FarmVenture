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
            Field field = other.GetComponent<Field>();
            if (field != null && !field.GetState().Equals(FieldState.Empty))
            {
                field.SetState(new EmptyState());
                Debug.Log("Tarla zaten satýn alýnmýþ!");
                return;
            }
            farmManager = other.GetComponent<FarmManager>();
            if (farmManager != null && farmManager.isPurchased==false)
            {
                ButtonInTrue();
                Debug.Log("Tarla satýn alýndý!");
               // field.SetState(new EmptyState());
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
            farmManager.isPurchased = true;
            
            Debug.Log("Tarla satýn alýndý!");
            ButtonInFalse();
        }
        else
        {
            Debug.Log("Yeterli para yok!");
        }
    }
}
