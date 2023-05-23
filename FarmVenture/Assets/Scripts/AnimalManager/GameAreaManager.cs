using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameAreaManager : MonoBehaviour
{
    public GameArea gameAreas; // Oyun alanlarýnýn listesi
    public MoneyManager moneyManager; // Para yöneticisi
    public PlayerSo playerSo;

    public void Deneme(GameArea gameAreas) 
    {
        this.gameAreas = gameAreas;
    
    }
    // Belirli bir alaný satýn al
    public void BuyArea()
    {
        //  GameArea area = gameObject
    

        if (gameAreas != null && !gameAreas.isUnlocked && gameAreas.areaName == "Cow")
        {
            if (moneyManager.CanAfford(gameAreas.price))
            {
                moneyManager.SpendMoney(gameAreas.price);
                gameAreas.UnlockArea();
                SaveGameCow(); // Oyunu kaydet
            }
            else
            {
                Debug.Log("Yetersiz para!");
            }
        }
        if (gameAreas != null && !gameAreas.isUnlocked && gameAreas.areaName == "Chicken")
        {
            if (moneyManager.CanAfford(gameAreas.price))
            {
                moneyManager.SpendMoney(gameAreas.price);
                gameAreas.UnlockArea();
                SaveGameChicken(); // Oyunu kaydet
            }
            else
            {
                Debug.Log("Yetersiz para!");
            }
        }
    }
  

    // Oyunu kaydet
    private void SaveGameCow()
    {
        // Oyunun kaydedilme kodu burada yer almalýdýr
        playerSo.cowAreaLimit += 10;
    }
    private void SaveGameChicken()
    {
        // Oyunun kaydedilme kodu burada yer almalýdýr
        playerSo.chickenAreaLimit += 10;
    }
}