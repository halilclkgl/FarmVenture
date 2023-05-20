using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

public class Milk : MonoBehaviour
{
    public SayProcess sayProcess;
    public WaterProcess waterProcess;
  
    public Harvest harvest;
    public int stok;
    private bool isSelling=false;
    public void MilkCow() 
    {
        stok = PlayerPrefs.GetInt("Stok");
        if (sayProcess.hayCow && waterProcess.waterCow) 
        {
            int cowCount = GameObject.FindGameObjectsWithTag("Cow").Length;
            stok += cowCount;

            PlayerPrefs.SetInt("Stok", stok);
            
        }
    }
   
 
    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
           
            stok = PlayerPrefs.GetInt("Stok");
           
            if (stok>0 )
            {
                MilkHarvesting();
                
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

    public void MilkHarvesting() 
    {
        
            if (harvest.harvestList.Count < 20 && stok > 0 )
            {
               // sayProcess.hayCow = false;
               // waterProcess.waterCow = false;
               
                PlayerPrefs.SetInt("Stok", stok);
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
        if (harvest.harvestList.Count < 20)
        {
            stok--;
            PlayerPrefs.SetInt("Stok", stok);
            harvest.PerformHarvest(2);
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
