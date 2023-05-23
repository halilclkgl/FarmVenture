using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EggControl : MonoBehaviour
{
    public int EggAmount; // Süt miktarý
    [SerializeField] private PlayerSo playerSo;
    public ChickenWater chickenWater;
    public ChickenFeed chickenFeed;

    public void CollectEgg()
    {
        if (chickenWater.waterChicken && chickenFeed.feedChicken)
        {
            int chickenCount = playerSo.chickenCount;
            Debug.Log("Egg Count: " + chickenCount);
            chickenCount -= EggAmount;

            if (chickenCount >= 15)
            {
                int stok = PlayerPrefs.GetInt("EggStock");
                stok += 10;
                PlayerPrefs.SetInt("EggStock", stok);
               
                ResetProcesses();
            }
            else if (chickenCount < 15 && chickenCount > 0)
            {
                int stok = PlayerPrefs.GetInt("EggStock");
                stok += chickenCount;
                PlayerPrefs.SetInt("EggStock", stok);
           
                ResetProcesses();
            }
        }
        else { return; }
    }

    private void ResetProcesses()
    {
        chickenFeed.feedChicken = false;
        chickenFeed.control = false;
        chickenWater.control = false;
        chickenWater.waterChicken = false;
    }
}
