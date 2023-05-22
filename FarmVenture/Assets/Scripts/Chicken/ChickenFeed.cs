using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickenFeed : MonoBehaviour
{

    public ProgressBarChicken progressBarChicken;
    public ChickenWater chickenWater;
    public bool feedChicken = false;
    public bool control = false;
    private float feedChickenBarFillDuration = 10f;

    void OnTriggerEnter(Collider other)
    {
       
        if (other.gameObject.tag == "Player" && !control)
        {
            control = true;

            StartCoroutine(FillCowHayBar());

            progressBarChicken.StartFillProgressBar();
        }
     
    }
    private IEnumerator FillCowHayBar()
    {
        yield return new WaitForSeconds(feedChickenBarFillDuration);

        feedChicken = true;
        if (chickenWater.waterChicken && feedChicken)
        {
            feedChicken = false;
            chickenWater.waterChicken = false;
          
            int chickenCount = GameObject.FindGameObjectsWithTag("Chicken").Length;
            int Stock = PlayerPrefs.GetInt("EggStock");
            Stock += chickenCount;
          
            PlayerPrefs.SetInt("EggStock", Stock);
            control = false;
            chickenWater.control = false;
        }
    }
}
