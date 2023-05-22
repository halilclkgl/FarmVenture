using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameAreaManager : MonoBehaviour
{
    public GameArea gameAreas; // Oyun alanlar�n�n listesi
    public MoneyManager moneyManager; // Para y�neticisi
    public PlayerSo playerSo;

    private void Start()
    {
        
    }

    // Belirli bir alan� sat�n al
    public void BuyArea(int areaID)
    {
        //  GameArea area = gameObject
        Debug.Log("Yetersiz para!123");
        if (gameAreas != null && !gameAreas.isUnlocked)
        {
            if (moneyManager.CanAfford(gameAreas.price))
            {
                moneyManager.SpendMoney(gameAreas.price);
                gameAreas.UnlockArea();
                SaveGame(); // Oyunu kaydet
            }
            else
            {
                Debug.Log("Yetersiz para!");
            }
        }
    }
  

    // Oyunu kaydet
    private void SaveGame()
    {
        // Oyunun kaydedilme kodu burada yer almal�d�r
        playerSo.cowAreaLimit += 10;
    }
}