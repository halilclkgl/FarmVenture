using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameArea :MonoBehaviour
{
    public string areaID;// Alanýn benzersiz kimliði

    public int unlockedCapacity;// Kilidi açýldýðýnda artacak kapasite
    
    public int price;// Alanýn fiyatý
    public bool isUnlocked;// Alanýn kilidi açýk mý?
    public Button areaBuy;
    private void Start()
    {
        // PlayerPrefs.DeleteKey(areaID);
        int purchasedValue = PlayerPrefs.GetInt(areaID);
        Debug.Log(PlayerPrefs.GetInt(areaID));
        isUnlocked = purchasedValue == 1;
        if (isUnlocked)
        {
            BoxCollider boxCollider = GetComponent<BoxCollider>();
            boxCollider.isTrigger = true;
        }
    }
    public void UnlockArea() 
    {
        isUnlocked = true;
        PlayerPrefs.SetInt(areaID, isUnlocked ? 1 : 0);
       
        BoxCollider boxCollider= GetComponent<BoxCollider>();
        boxCollider.isTrigger= true;
        areaBuy.gameObject.SetActive(false);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (!isUnlocked && collision.gameObject.tag=="Player")
        {
            areaBuy.gameObject.SetActive(true);
        }
    }

   
}
