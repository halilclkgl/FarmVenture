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
            Debug.Log("Cow Count: " + cowCount);
            cowCount -= milkAmount;

            if (cowCount >= 10)
            {
                int stok = PlayerPrefs.GetInt("Stok");
                stok += 10;
                PlayerPrefs.SetInt("Stok", stok);
                Debug.Log("10 adet süt eklendi");
                ResetProcesses();
            }
            else if (cowCount < 10 && cowCount > 0)
            {
                int stok = PlayerPrefs.GetInt("Stok");
                stok += cowCount;
                PlayerPrefs.SetInt("Stok", stok);
                Debug.Log(cowCount + " adet süt eklendi");
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
