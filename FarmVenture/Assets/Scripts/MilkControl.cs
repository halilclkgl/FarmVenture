using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MilkControl : MonoBehaviour
{
    public int milkAmount; // Süt miktarý
    [SerializeField] private PlayerSo playerSo;
    public HayProcess hayProcess;
    public WaterProcess waterProcess;

    public void CollectMilk()
    {
        if (hayProcess.hayCow && waterProcess.waterCow)
        {
            int cowCount = playerSo.cowCount;
            cowCount -= milkAmount;

            if (cowCount >= 10)
            {
                int stok = PlayerPrefs.GetInt("Stok");
                stok += 10;
                PlayerPrefs.SetInt("Stok", stok);
                ResetProcesses();
            }
            else if (cowCount < 10 && cowCount > 0)
            {
                int stok = PlayerPrefs.GetInt("Stok");
                stok += cowCount;
                PlayerPrefs.SetInt("Stok", stok);
                ResetProcesses();
            }
            else 
            {
                ResetProcesses();
            }
        }
    }

    private void ResetProcesses()
    {
        waterProcess.waterCow = false;
        waterProcess.control = false;
        hayProcess.control = false;
        hayProcess.hayCow = false;
    }

}
