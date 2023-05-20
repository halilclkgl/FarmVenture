using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickenWater : MonoBehaviour
{
     public ProgressBarChicken progressBarChicken;
    public ChickenFeed chickenFeed;
    public bool waterChicken = false;
    public bool control = false;
    private float cowHayBarFillDuration = 10f;

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
        yield return new WaitForSeconds(cowHayBarFillDuration);

        waterChicken = true;
        if (waterChicken && chickenFeed.feedChicken)
        {
            chickenFeed.feedChicken = false;
            waterChicken = false;
            int chickenCount = GameObject.FindGameObjectsWithTag("Chicken").Length;
            int Stock = PlayerPrefs.GetInt("EggStock");
            Stock += chickenCount;
            Debug.Log(Stock);
            PlayerPrefs.SetInt("EggStock", Stock);
            control = false;
            chickenFeed.control = false;
        }
    }
}
