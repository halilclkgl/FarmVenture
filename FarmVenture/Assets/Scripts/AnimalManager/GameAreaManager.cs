using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameAreaManager : MonoBehaviour
{
    public GameArea gameAreas; // Oyun alanlarýnýn listesi
    public MoneyManager moneyManager; // Para yöneticisi
    public PlayerSo playerSo;

    private void Start()
    {
        
    }

    // Belirli bir alaný satýn al
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
        // Oyunun kaydedilme kodu burada yer almalýdýr
        playerSo.cowAreaLimit += 10;
    }
}