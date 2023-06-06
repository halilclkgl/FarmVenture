using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUpgrade : MonoBehaviour
{
    public PlayerSo playerSo;
    public MoneyManager moneyManager;
    public int harvesUpgrade = 200;
    public int playerSpeedUpgrade = 300;
    public int playerHavrestSpeedUpgrade = 300;
    public GameObject insufficientMoney;
    public GameObject insufficientLimit;
    public void PlayerHarvestCountUpgrade()
    {
        if (moneyManager.CanAfford(harvesUpgrade))
        {
            playerSo.playerHarvestCount++;
            moneyManager.SpendMoney(harvesUpgrade);
        }
        else if (playerSo.playerHarvestCount>= 30)
        {
            StartCoroutine(InsufficientLimit());
        }
        else 
        {
            StartCoroutine(InsufficientMoney());
        }
    
    }
    public void PlayerSpeedUpgrade()
    {
        if (moneyManager.CanAfford(playerSpeedUpgrade) && playerSo.playerSpeed < 8f)
        {
            playerSo.playerSpeed += 0.2f;
            playerSo.horseSpeed += 0.2f;
            moneyManager.SpendMoney(playerSpeedUpgrade);
        }
        else if (playerSo.playerSpeed >= 8f) 
        {
            StartCoroutine(InsufficientLimit());
        }
        else
        {
            StartCoroutine(InsufficientMoney());
        }
        if (playerSo.playerHarvestSpeed>8) 
        {
            playerSo.playerHarvestSpeed = 8;
        }

    }
    public void PlayerHarvestSpeedUpgrade()
    {
        if (moneyManager.CanAfford(playerHavrestSpeedUpgrade) && playerSo.harvestSpeed >= 0.1f)
        {
            playerSo.playerHarvestSpeed += 0.05f;
            moneyManager.SpendMoney(playerHavrestSpeedUpgrade);
        }
        else if (playerSo.harvestSpeed < 0.1f)
        {
            StartCoroutine(InsufficientLimit());
        }
        else
        {
            StartCoroutine(InsufficientMoney());
        }

    }


    IEnumerator InsufficientMoney()
    {
        insufficientMoney.SetActive(true);
        yield return new WaitForSeconds(0.25f);
        insufficientMoney.SetActive(false);
    }

    IEnumerator InsufficientLimit()
    {
        insufficientMoney.SetActive(true);
        yield return new WaitForSeconds(0.25f);
        insufficientMoney.SetActive(false);
    }
}
