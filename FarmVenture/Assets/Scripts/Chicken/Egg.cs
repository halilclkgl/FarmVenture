using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Egg : MonoBehaviour
{
    public Harvest harvest;
    public int stok;
    private bool isSelling = false;
    public PlayerSo playerSo;
    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {

            stok = PlayerPrefs.GetInt("EggStock");

            if (stok > 0)
            {
                EggHarvesting();

            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            StopSelling();
        }

    }

    public void EggHarvesting()
    {

        if (harvest.harvestList.Count < 20 && stok > 0)
        {
          
            PlayerPrefs.SetInt("EggStock", stok);
            StartSelling();
        }
        else
        {
            return;
        }

    }

    private void StartSelling()
    {
        if (!isSelling)
        {
            isSelling = true;
            InvokeRepeating("SellHarvest", 1f, 1f); // 0.2 saniyede bir SellHarvest metodunu çaðýr
        }
    }

    private void SellHarvest()
    {
        if (harvest.harvestList.Count <playerSo.playerHarvestCount && stok > 0)
        {
            stok--;
            PlayerPrefs.SetInt("EggStock", stok);
            harvest.PerformHarvest(3);
        }
        else
        {
            return;
        }
    }

    private void StopSelling()
    {
        isSelling = false;
        CancelInvoke("SellHarvest"); // Satýþ iþlemini durdur
    }
}

