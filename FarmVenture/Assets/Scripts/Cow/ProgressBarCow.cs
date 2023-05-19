using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class ProgressBarCow : MonoBehaviour
{
    public Milk milk;
    public UnityEngine.UI.Image progressBar;
    public float fillDuration = 2f; // Ýlerleme süresi (saniye)
    public float reverseDuration = 12f;


    public void StartFillProgressBar()
    {
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
     
        progressBar.fillAmount = 0f; // Ýlerleme çubuðunu tamamen boþalt
    }
    private void OnProgressBarFilled()
    {
        StartCoroutine(EmptyProgressBar());
       
        Debug.Log("Ýlerleme çubuðu tamamlandý!");
    }

}
