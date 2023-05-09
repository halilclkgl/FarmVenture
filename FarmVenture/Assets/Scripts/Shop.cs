using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public Harvest harvest; // Harvest sýnýfýna eriþmek için referans
    private bool isSelling; // Satýþ iþleminin devam edip etmediðini takip etmek için bir bayrak

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            harvest = other.gameObject.GetComponent<Harvest>();
            Debug.Log("Player ile temas saðlandý");
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
            InvokeRepeating("SellHarvest", 1f, 1f); // 0.2 saniyede bir SellHarvest metodunu çaðýr
        }
    }

    private void SellHarvest()
    {
        if (harvest.harvestList.Count > 0)
        {
            harvest.SellHarvest(); // Harvest sýnýfýndaki SellHarvest metoduyla ayný iþlemi yap
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
        CancelInvoke("SellHarvest"); // Satýþ iþlemini durdur
    }

}
