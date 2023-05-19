using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AnimalManager : MonoBehaviour
{
    public GameObject[] Animal;
    public MoneyManager moneyManager;
    public GameObject animalShopPanel;
    public Transform cowSpawnPoint;
    public Transform cowSpawnPoint2;
    public Transform cockSpawnPoint;
    public Transform ChickenSpawnPoint;
    public Transform ChickenSpawnPoint2;
    public GameObject cowPrefab;
    public GameObject cowPrefab2;
    public GameObject Chicken;
    public GameObject Cock;
    public GameObject Chicken2;
    public int cowCount = 0;
    public int cowCount2 = 0;
    public int chickenCount = 0;
    public int chickenCount2 = 0;
    public int CockCount = 0;

    private void Awake()
    {

        chickenCount = PlayerPrefs.GetInt("chickenCount", 0);
        chickenCount2 = PlayerPrefs.GetInt("chickenCount2", 0);
        CockCount = PlayerPrefs.GetInt("CockCount", 0);
        cowCount = PlayerPrefs.GetInt("CowCount", 0);
        cowCount2 = PlayerPrefs.GetInt("CowCount2", 0);// Oyuncu tercihinden cowCount deðerini al
        SpawnCows(cowCount, cowCount2); // cowCount deðerine göre hayvanlarý spawn et
        SpawnChickens(chickenCount, chickenCount2);
        SpawnCocks(CockCount);
    }

    private void Start()
    {
        LoadCowCount();

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            OpenAnimalShopPanel();

        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            CloseAnimalShopPanel();

        }
    }
    private void SpawnCows(int count, int count2)
    {
        for (int i = 0; i < count; i++)
        {
            GameObject newCow = Instantiate(cowPrefab, cowSpawnPoint.position, cowSpawnPoint.rotation);
            newCow.transform.parent = Animal[1].transform;

        }
        for (int i = 0; i < count2; i++)
        {
            GameObject newCow2 = Instantiate(cowPrefab2, cowSpawnPoint2.position, cowSpawnPoint2.rotation);
            newCow2.transform.parent = Animal[1].transform;
        }

    }
    private void SpawnChickens(int count, int count2)
    {
        for (int i = 0; i < count; i++)
        {
            GameObject newChicken = Instantiate(Chicken, ChickenSpawnPoint.position, ChickenSpawnPoint.rotation);
            newChicken.transform.parent = Animal[0].transform;
        }
        for (int i = 0; i < count2; i++)
        {
            GameObject newChicken2 = Instantiate(Chicken2, ChickenSpawnPoint2.position, ChickenSpawnPoint2.rotation);
            newChicken2.transform.parent = Animal[0].transform;
        }
    }
    private void SpawnCocks(int count)
    {
        for (int i = 0; i < count; i++)
        {
            GameObject newCock = Instantiate(Cock, cockSpawnPoint.position, cockSpawnPoint.rotation);
            newCock.transform.parent = Animal[0].transform;
        }

    }
    public void OpenAnimalShopPanel()
    {
        animalShopPanel.SetActive(true);
    }
    public void CloseAnimalShopPanel()
    {
        animalShopPanel.SetActive(false);
    }
    public void BuyCow()
    {
        if (moneyManager.money >= 1350)
        {
            moneyManager.SpendMoney(1350);
            Debug.Log(moneyManager.money);
            GameObject newCow = Instantiate(cowPrefab, cowSpawnPoint.position, cowSpawnPoint.rotation);
            cowCount++;
            SaveCowCount();

        }
        else { Debug.Log("Yetersiz bakiye"); }

    }
    public void BuyCow2()
    {
        if (moneyManager.money >= 1350)
        {
            moneyManager.SpendMoney(1350);
            Debug.Log(moneyManager.money);
            GameObject newCow = Instantiate(cowPrefab2, cowSpawnPoint2.position, cowSpawnPoint2.rotation);
            cowCount2++;
            SaveCowCount();
        }
        else { Debug.Log("Yetersiz bakiye"); }
    }
    public void BuyChicken()
    {
        if (moneyManager.money >= 350)
        {
            moneyManager.SpendMoney(350);
            GameObject newCow = Instantiate(Chicken, ChickenSpawnPoint.position, ChickenSpawnPoint.rotation);
            chickenCount++;
            SaveCowCount();
        }
        else { Debug.Log("Yetersiz bakiye"); }
    }
    public void BuyChicken2()
    {
        if (moneyManager.money >= 350)
        {
            moneyManager.SpendMoney(350);
            GameObject newCow = Instantiate(Chicken2, ChickenSpawnPoint2.position, ChickenSpawnPoint2.rotation);
            chickenCount2++;
            SaveCowCount();
        }
        else
        {
            Debug.Log("Yetersiz bakiye");
        }
    }
    public void BuyCock()
    {
        if (moneyManager.money >= 350)
        {
            moneyManager.SpendMoney(350);
            GameObject newCow = Instantiate(Cock, cockSpawnPoint.position, cockSpawnPoint.rotation);
            CockCount++;
            SaveCowCount();
        }
        else
        {
            Debug.Log("Yetersiz bakiye");
        }
    }

    public void SaveCowCount()
    {
        PlayerPrefs.SetInt("chickenCount", chickenCount);
        PlayerPrefs.SetInt("chickenCount2", chickenCount2);
        PlayerPrefs.SetInt("CockCount", CockCount);
        PlayerPrefs.SetInt("CowCount", cowCount);
        PlayerPrefs.SetInt("CowCount2", cowCount2);
    }

    public void LoadCowCount()
    {
        cowCount = PlayerPrefs.GetInt("CowCount");
        cowCount2 = PlayerPrefs.GetInt("CowCount2");
        CockCount = PlayerPrefs.GetInt("CockCount");
        chickenCount = PlayerPrefs.GetInt("chickenCount");
        chickenCount2 = PlayerPrefs.GetInt("chickenCount2");
        // Ýnek sayýsýna göre inekleri sahneye yeniden yerleþtir
    }

    // Sahnenin durdurulduðu veya uygulama kapandýðýnda çaðrýlacak bir metodunuz varsa
    // aþaðýdaki metodlarý kullanabilirsiniz.

    private void OnApplicationPause(bool pauseStatus)
    {
        if (pauseStatus)
        {
            SaveCowCount();
        }
    }

    private void OnApplicationQuit()
    {
        SaveCowCount();
    }
}

