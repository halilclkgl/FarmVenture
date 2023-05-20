using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    [SerializeField] private ShopDatabaseSO shopDatabaseSO;
    private ShopDatabase shopDatabase;
    [SerializeField] private MoneyManager moneyManager;
    public Harvest harvest; // Harvest s�n�f�na eri�mek i�in referans
    private int a;
    private bool isSelling; // Sat�� i�leminin devam edip etmedi�ini takip etmek i�in bir bayrak

    private void Start()
    {
        shopDatabase = shopDatabaseSO.shopDatabase;
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StopSelling();
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag("Player"))
        {
            harvest = other.gameObject.GetComponent<Harvest>();
           
            StartSelling();
        }
        else if (other.CompareTag("Car"))
        {
            float randomValue = Random.value; // Rastgele bir de�er se� (0-1 aras�nda)

            if (randomValue < 0.33f) // 0.33 ihtimalle
            {
                // 1 �r�n al
                SellRandomProduct();
            }
            else if (randomValue < 0.66f) // 0.33 ihtimalle
            {
                // 2 farkl� �r�n al
                SellRandomProducts(2);
            }
            else if (randomValue < 0.99f) // 0.33 ihtimalle
            {
                // Her �r�nden farkl� say�larda al
                SellRandomProducts(3);
            }
            else // 0.01 ihtimalle
            {
                // Hi�bir �ey almadan ��k
            }
        }
    }

    private void SellRandomProduct()
    {
        List<string> availableProducts = GetAvailableProducts();

        if (availableProducts.Count > 0)
        {
            int randomProductIndex = Random.Range(0, availableProducts.Count);
            string productName = availableProducts[randomProductIndex];
            SellProduct(productName);
        }
    }

   

    private void StartSelling()
    {
        if (!isSelling)
        {
            isSelling = true;
            InvokeRepeating("StokHarvest", 1f, 1f); // 0.2 saniyede bir SellHarvest metodunu �a��r
        }
    }

    private void StokHarvest()
    {
        if (harvest.harvestList.Count > 0)
        {
            harvest.StokHarvest(); // Harvest s�n�f�ndaki SellHarvest metoduyla ayn� i�lemi yap
            harvest.spawnPoint.position -= new Vector3(0, 0.5f, 0);
        }
        else
        {
            StopSelling();
        }
    }
    private void SellRandomProducts(int productCount)
    {
        List<string> availableProducts = GetAvailableProducts();

        if (availableProducts.Count >= productCount)
        {
            for (int i = 0; i < productCount; i++)
            {
                int randomProductIndex = Random.Range(0, availableProducts.Count);
                string productName = availableProducts[randomProductIndex];
                SellProduct(productName);
                availableProducts.RemoveAt(randomProductIndex);
            }
        }
        else if (availableProducts.Count > 0)
        {
            for (int i = 0; i < availableProducts.Count; i++)
            {
                string productName = availableProducts[i];
                SellProduct(productName);
            }
        }
    }
    private void SellProduct(string productName)
    {
        ShopItem shopItem = shopDatabase.GetItemByName(productName);

        if (shopItem != null && shopItem.stock > 0)
        {
            moneyManager.AddMoney(shopItem.price);
            shopDatabase.UpdateStock(productName, shopItem.stock - 1);
        }
    }

    private List<string> GetAvailableProducts()
    {
        List<string> availableProducts = new List<string>();

        if (shopDatabase.GetItemByName("Tomato")?.stock > 0)
        {
            availableProducts.Add("Tomato");
        }

        if (shopDatabase.GetItemByName("Egg")?.stock > 0)
        {
            availableProducts.Add("Egg");
        }

        if (shopDatabase.GetItemByName("Milk")?.stock > 0)
        {
            availableProducts.Add("Milk");
        }

        return availableProducts;
    }

    private void StopSelling()
    {
        isSelling = false;
        CancelInvoke("StokHarvest"); // Sat�� i�lemini durdur
    }

}
