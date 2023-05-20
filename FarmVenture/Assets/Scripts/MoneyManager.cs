using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MoneyManager : MonoBehaviour
{
    [SerializeField] private TMP_Text moneyText;
    private const string PlayerPrefsKey = "Money";
    private int money = 500; // Kullanıcının başlangıç parası
    private void Start()
    {
      
        money = PlayerPrefs.GetInt(PlayerPrefsKey, 0);
        moneyText.text = "MONEY : " + money;

    }
    private void SaveMoney()
    {
        PlayerPrefs.SetInt(PlayerPrefsKey, money);
        moneyText.text = "MONEY : " + money;
    }
    public int GetMoney()
    {
        return money;
    }

    public bool SpendMoney(int amount)
    {
        if (money >= amount)
        {
            money -= amount;
            SaveMoney();
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
    
        SaveMoney();
    }
}
