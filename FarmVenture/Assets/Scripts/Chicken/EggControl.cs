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
        Debug.Log(chickenFeed.feedChicken+"  feed");
        Debug.Log(chickenWater.waterChicken+"  water");
        Debug.Log(chickenWater.waterChicken && chickenFeed.feedChicken);
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
                Debug.Log("10 adet yumurta eklendi");
                ResetProcesses();
            }
            else if (chickenCount < 15 && chickenCount > 0)
            {
                int stok = PlayerPrefs.GetInt("EggStock");
                stok += chickenCount;
                PlayerPrefs.SetInt("EggStock", stok);
                Debug.Log(chickenCount + " adet yumurta eklendi");
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
