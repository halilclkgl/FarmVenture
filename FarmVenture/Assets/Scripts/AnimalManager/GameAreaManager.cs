using System.Collections;
using System.Collections.Generic;
using System.Linq;
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

        if (gameAreas != null && !gameAreas.isUnlocked)
        {
            if (moneyManager.CanAfford(gameAreas.price))
            {
                moneyManager.SpendMoney(gameAreas.price);
                gameAreas.UnlockArea();
                

                switch (gameAreas.areaName)
                {
                    case "Cow":
                        SaveGameCow(); // Oyunu kaydet
                        SpawnCow();
                        break;
                    case "Chicken":
                        SaveGameChicken(); // Oyunu kaydet
                        SpawnChicken();
                        break;
                    // Di�er hayvan t�rleri i�in case'ler eklenebilir
                    default:
                        Debug.Log("Bilinmeyen hayvan t�r�: " + gameAreas.areaName);
                        break;
                }
            }
            else
            {
                Debug.Log("Yetersiz para!");
            }
        }
        
    }
    private void SpawnCow()
    {
        AnimalMoveManager aimalMoveManager = AnimalMoveManager.Instance;
        Transform[] waypoints = gameAreas.waypoints.Select(item => item.transform).ToArray();
        aimalMoveManager.AddCowWaypoints(waypoints);
    }

    private void SpawnChicken()
    {
        AnimalMoveManager aimalMoveManager = AnimalMoveManager.Instance;
        Transform[] waypoints = gameAreas.waypoints.Select(item => item.transform).ToArray();
        aimalMoveManager.AddChickenWaypoints(waypoints);
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
        playerSo.chickenAreaLimit += 15;
    }
}