using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AnimalManager : MonoBehaviour
{
    [SerializeField] private GameObject[] Animal;

    [Header("Money Settings")]
    [SerializeField] private MoneyManager moneyManager;

    [Header("PlayerSo Settings")]
    [SerializeField] private PlayerSo playerSo;

    [Header("Animal Shop")]
    [SerializeField] private GameObject animalShopPanel;

    [Header("Spawn Points")]
    [SerializeField] private Transform cowSpawnPoint;
    [SerializeField] private Transform cowSpawnPoint2;
    [SerializeField] private Transform cockSpawnPoint;
    [SerializeField] private Transform ChickenSpawnPoint;
    [SerializeField] private Transform ChickenSpawnPoint2;

    [Header("Prefabs")]
    [SerializeField] private GameObject cowPrefab;
    [SerializeField] private GameObject cowPrefab2;
    [SerializeField] private GameObject Chicken;
    [SerializeField] private GameObject Cock;
    [SerializeField] private GameObject Chicken2;

    [Header("Animal Counts")]
    [SerializeField] private int cowCount = 0;
    [SerializeField] private int cowCount2 = 0;
    [SerializeField] private int chickenCount = 0;
    [SerializeField] private int chickenCount2 = 0;
    [SerializeField] private int CockCount = 0;

    private void Awake()
    {

        /*
        PlayerPrefs.SetInt("chickenCount", 0);
        PlayerPrefs.SetInt("chickenCount2", 0);
        PlayerPrefs.SetInt("CockCount", 0);
        PlayerPrefs.SetInt("CowCount", 0);
        PlayerPrefs.SetInt("CowCount2", 0);*/
        chickenCount = PlayerPrefs.GetInt("chickenCount", 0);
        chickenCount2 = PlayerPrefs.GetInt("chickenCount2", 0);
        CockCount = PlayerPrefs.GetInt("CockCount", 0);
        cowCount = PlayerPrefs.GetInt("CowCount", 0);
        cowCount2 = PlayerPrefs.GetInt("CowCount2", 0);// Oyuncu tercihinden cowCount deðerini al
        SpawnCows(cowCount, cowCount2); // cowCount deðerine göre hayvanlarý spawn et
        SpawnChickens(chickenCount, chickenCount2);
        SpawnCocks(CockCount);
        playerSo.cowCount = cowCount + cowCount2;
        playerSo.chickenCount= chickenCount + chickenCount2;
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
        if (moneyManager.GetMoney() >= 1350 && playerSo.cowAreaLimit > playerSo.cowCount)
        {
            Debug.Log(playerSo.cowAreaLimit >= cowCount);

                
            moneyManager.SpendMoney(1350);
            Debug.Log(moneyManager.GetMoney());
            GameObject newCow = Instantiate(cowPrefab, cowSpawnPoint.position, cowSpawnPoint.rotation);
            newCow.transform.parent = Animal[1].transform;
            cowCount++;
            SaveCowCount();
            playerSo.cowCount = cowCount + cowCount2;
        }
        else { Debug.Log("Yetersiz bakiye21"); }

    }
    public void BuyCow2()
    {
        if (moneyManager.GetMoney() >= 1350 && playerSo.cowAreaLimit > playerSo.cowCount)
        {
            Debug.Log(playerSo.cowAreaLimit >= cowCount);
            moneyManager.SpendMoney(1350);
            Debug.Log(moneyManager.GetMoney());
            GameObject newCow = Instantiate(cowPrefab2, cowSpawnPoint2.position, cowSpawnPoint2.rotation);
            newCow.transform.parent = Animal[1].transform;
            cowCount2++;
            playerSo.cowCount = cowCount + cowCount2;
            SaveCowCount();
        }
        else { Debug.Log("Yetersiz bakiye12"); }
    }
    public void BuyChicken()
    {
        if (moneyManager.GetMoney() >= 350 && playerSo.chickenAreaLimit > playerSo.chickenCount)
        {
            moneyManager.SpendMoney(350);
            GameObject newChicken = Instantiate(Chicken, ChickenSpawnPoint.position, ChickenSpawnPoint.rotation);
            newChicken.transform.parent = Animal[0].transform;
            chickenCount++;
            SaveCowCount();
            playerSo.chickenCount = chickenCount + chickenCount2;
        }
        else { Debug.Log("Yetersiz bakiye"); }
    }
    public void BuyChicken2()
    {
        if (moneyManager.GetMoney() >= 350 && playerSo.chickenAreaLimit > playerSo.chickenCount)
        {
            moneyManager.SpendMoney(350);
            GameObject newChicken2 = Instantiate(Chicken2, ChickenSpawnPoint2.position, ChickenSpawnPoint2.rotation);
            newChicken2.transform.parent = Animal[0].transform;
            chickenCount2++;
            SaveCowCount();
          
            playerSo.chickenCount = chickenCount + chickenCount2;
        }
        else
        {
            Debug.Log("Yetersiz bakiye");
        }
    }
    public void BuyCock()
    {
        if (moneyManager.GetMoney() >= 350 && playerSo.chickenAreaLimit > playerSo.chickenCount)
        {
            moneyManager.SpendMoney(350);
            GameObject newCock = Instantiate(Cock, cockSpawnPoint.position, cockSpawnPoint.rotation);
            newCock.transform.parent = Animal[0].transform;
            CockCount++;
            SaveCowCount();
            playerSo.chickenCount = chickenCount + chickenCount2;
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

