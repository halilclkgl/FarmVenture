using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgressBarChicken : MonoBehaviour
{
    public Egg egg;
    public UnityEngine.UI.Image progressBar;
    public float fillDuration = 2f; // Ýlerleme süresi (saniye)
    public float reverseDuration = 12f;
    private ChickenFeed chickenFeed;
    private ChickenWater chickenWater;

    public void StartFillProgressBar()
    {
        StartCoroutine(FillProgressBar());
    }
    public void StartFillProgressBar(ChickenWater chickenWater)
    {
        this.chickenWater = chickenWater;
        StartCoroutine(FillProgressBar());
    }
    public void StartFillProgressBar(ChickenFeed chickenFeed)
    {
        this.chickenFeed = chickenFeed;
        StartCoroutine(FillProgressBar());
    }

    private IEnumerator FillProgressBar()
    {
        float timer = 0f;

        while (timer < fillDuration)
        {
            timer += Time.deltaTime;

            // Ýlerleme çubuðunu güncelle
            float fillAmount = Mathf.Clamp01(timer / fillDuration);
            progressBar.fillAmount = fillAmount;

            yield return null;
        }
        // Ýlerleme tamamlandýðýnda yapýlacak iþlemler
        OnProgressBarFilled();

    }
    private IEnumerator EmptyProgressBar()
    {
        float timer = reverseDuration;

        while (timer > 0f)
        {
            timer -= Time.deltaTime;
            // Ýlerleme çubuðunu güncelle
            float fillAmount = Mathf.Clamp01(timer / reverseDuration);
            progressBar.fillAmount = fillAmount;

            yield return null;
        }
        if (chickenWater)
        {
            chickenWater.waterChicken = true;
            chickenWater.CollectEggFromChick();
        }
        if (chickenFeed)
        {

            chickenFeed.feedChicken = true;
            chickenFeed.CollectEggFromChick();
        }

        progressBar.fillAmount = 0f; // Ýlerleme çubuðunu tamamen boþalt
    }
    private void OnProgressBarFilled()
    {
        StartCoroutine(EmptyProgressBar());
    }

}
