using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyManager : MonoBehaviour
{
    public int money = 1000; // Kullanıcının başlangıç parası

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
