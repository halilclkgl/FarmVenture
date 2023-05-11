using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyManager : MonoBehaviour
{
    public int money = 1000; // Kullan�c�n�n ba�lang�� paras�

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
