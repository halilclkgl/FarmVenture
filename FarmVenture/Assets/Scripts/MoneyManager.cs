using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MoneyManager : MonoBehaviour
{
    [SerializeField] private TMP_Text moneyText;
    public int money = 1000; // Kullanıcının başlangıç parası
    private void Start()
    {
        moneyText.text = "MONEY : " + money;

    }
    public bool SpendMoney(int amount)
    {
        if (money >= amount)
        {
            money -= amount;
            return true;
        }
        else
        {
            return false;
        }
    }

    public void AddMoney(int amount)
    {
        money += amount;
    }
}
