using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameAreaManager : MonoBehaviour
{
    public GameArea gameAreas; // Oyun alanlar�n�n listesi
    public MoneyManager moneyManager; // Para y�neticisi
    public PlayerSo playerSo;

    public void Deneme(GameArea gameAreas) 
    {
        this.gameAreas = gameAreas;
    
    }
    // Belirli bir alan� sat�n al
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
        // Oyunun kaydedilme kodu burada yer almal�d�r
        playerSo.cowAreaLimit += 10;
    }
    private void SaveGameChicken()
    {
        // Oyunun kaydedilme kodu burada yer almal�d�r
        playerSo.chickenAreaLimit += 10;
    }
}