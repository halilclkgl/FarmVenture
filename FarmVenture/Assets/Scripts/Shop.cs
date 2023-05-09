using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public Harvest harvest; // Harvest s�n�f�na eri�mek i�in referans
    private bool isSelling; // Sat�� i�leminin devam edip etmedi�ini takip etmek i�in bir bayrak

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            harvest = other.gameObject.GetComponent<Harvest>();
            Debug.Log("Player ile temas sa�land�");
            StartSelling();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StopSelling();
        }
    }

    private void StartSelling()
    {
        if (!isSelling)
        {
            isSelling = true;
            InvokeRepeating("SellHarvest", 1f, 1f); // 0.2 saniyede bir SellHarvest metodunu �a��r
        }
    }

    private void SellHarvest()
    {
        if (harvest.harvestList.Count > 0)
        {
            harvest.SellHarvest(); // Harvest s�n�f�ndaki SellHarvest metoduyla ayn� i�lemi yap
            harvest.spawnPoint.position -= new Vector3(0, 0.5f, 0);
        }
        else
        {
            StopSelling();
        }
    }

    private void StopSelling()
    {
        isSelling = false;
        CancelInvoke("SellHarvest"); // Sat�� i�lemini durdur
    }

}
