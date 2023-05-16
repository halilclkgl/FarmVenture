using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FieldManager : MonoBehaviour
{
    private Field field;
    public Button button;
    public MoneyManager moneyManager;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Field"))
        {
            field = (Field)other.GetComponent<Field>();
            if (!field.isPurchased)
            {
                button.gameObject.SetActive(true);
            }

        }
    }
    private void OnTriggerExit(Collider other)
    {
        button.gameObject.SetActive(false);
    }
    public void BuyField()
    {
        if (moneyManager.money > 50)
        {
            moneyManager.money -= 50;
            field.SavePurchaseStatus();
            button.gameObject.SetActive(false);
        }
    }
}
