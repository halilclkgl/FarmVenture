using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Harvest : MonoBehaviour
{
    [SerializeField] private ShopDatabaseSO shopDatabaseSO;
    private ShopDatabase shopDatabase;
    [SerializeField] private MoneyManager moneyManager;

    public GameObject harvestPrefab;
    public GameObject harvestPrefab2;
    public GameObject harvestPrefab3;
    public Transform spawnPoint;
    public GameObject harvestPrefab4;
    public List<GameObject> harvestList = new List<GameObject>(); // Hasat prefablar�n� saklamak i�in liste
    public Milk milk;
    public PlayerSo playerSo;

    private void Start()
    {
        shopDatabase = shopDatabaseSO.shopDatabase;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Field"))
        {
            // FieldInteraction fieldInteraction = other.GetComponent<FieldInteraction>();
        }
        if (other.gameObject.tag == "CowHay" || other.gameObject.tag == "CowWater" || other.gameObject.tag == "Milk")
        {
         //   milk.MilkCow();
        }
    }
  
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Field"))
        {
        }
    }

    public void PerformHarvest(int a)
    {
        if (harvestList.Count < playerSo.playerHarvestCount)
        {
            if (a == 1)
            {
                GameObject newHarvest = Instantiate(harvestPrefab, spawnPoint.position, spawnPoint.rotation);
                newHarvest.transform.parent = harvestPrefab4.transform; // Harvest objesinin alt�nda kalmas�n� sa�la
                harvestList.Insert(0, newHarvest); // Listeye en ba�a ekle
        
            }
            else if (a == 2)
            {
                GameObject newHarvest2 = Instantiate(harvestPrefab2, spawnPoint.position, spawnPoint.rotation);
                newHarvest2.transform.parent = harvestPrefab4.transform; // Harvest objesinin alt�nda kalmas�n� sa�la
                harvestList.Insert(0, newHarvest2); // Listeye en ba�a ekle
            }
            else if (a == 3)
            {
                GameObject newHarvest3 = Instantiate(harvestPrefab3, spawnPoint.position, spawnPoint.rotation);
                newHarvest3.transform.parent = harvestPrefab4.transform; // Harvest objesinin alt�nda kalmas�n� sa�la
                harvestList.Insert(0, newHarvest3); // Listeye en ba�a ekle
            }

            NewSpawnPoint();
        }
    }
  

    public void StokHarvest()
    {
        if (harvestList.Count > 0)
        {
            GameObject harvest = harvestList[0].gameObject;
            // Etikete g�re sat�� yap�lacak i�lemler
            if (harvest.CompareTag("MilkHarvest"))
            {
                ShopItem shopItem = shopDatabase.GetItemByName("Milk"); // "Milk" etiketine sahip shop nesnesini bul
                if (shopItem != null)
                {
                   
                    shopDatabase.UpdateStock("Milk", shopItem.stock + 1); // Stoku g�ncelle
                }
            }
            else if (harvest.CompareTag("Harvest"))
            {
                ShopItem shopItem = shopDatabase.GetItemByName("Tomato"); // "Vegetable" etiketine sahip shop nesnesini bul
                if (shopItem != null)
                {
                   
                    shopDatabase.UpdateStock("Tomato", shopItem.stock + 1); // Stoku g�ncelle
                }
            }
            else if (harvest.CompareTag("EggHarvest"))
            {
                ShopItem shopItem = shopDatabase.GetItemByName("Egg"); // "Vegetable" etiketine sahip shop nesnesini bul
                if (shopItem != null)
                {

                    shopDatabase.UpdateStock("Egg", shopItem.stock + 1); // Stoku g�ncelle
                }
            }

            Destroy(harvest); // En �stteki hasat� yok et
            harvestList.RemoveAt(0); // Listeden ��kar
        }
    }
    void NewSpawnPoint()
    {
        spawnPoint.position += new Vector3(0, 0.5f, 0); // spawnPoint'i bir birim yukar� kayd�r
    }
}
