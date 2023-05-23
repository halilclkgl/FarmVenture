using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class ProgressBarCow : MonoBehaviour
{
    public UnityEngine.UI.Image progressBar;
    public float fillDuration = 2f; // �lerleme s�resi (saniye)
    public float reverseDuration = 12f;

    private WaterProcess waterProcess;
    private HayProcess hayProcess;


    public void StartFillProgressBar(WaterProcess waterProcess)
    {
        this.waterProcess = waterProcess;
        StartCoroutine(FillProgressBar());
    }
    public void StartFillProgressBar(HayProcess hayProcess)
    {
        this.hayProcess= hayProcess;
        StartCoroutine(FillProgressBar());
    }

    private IEnumerator FillProgressBar()
    {
        float timer = 0f;

        while (timer < fillDuration)
        {
            timer += Time.deltaTime;

            // �lerleme �ubu�unu g�ncelle
            float fillAmount = Mathf.Clamp01(timer / fillDuration);
            progressBar.fillAmount = fillAmount;

            yield return null;
        }

        // �lerleme tamamland���nda yap�lacak i�lemler
        OnProgressBarFilled();

    }
    private IEnumerator EmptyProgressBar()
    {
        float timer = reverseDuration;

        while (timer > 0f)
        {
            timer -= Time.deltaTime;

            // �lerleme �ubu�unu g�ncelle
            float fillAmount = Mathf.Clamp01(timer / reverseDuration);
            progressBar.fillAmount = fillAmount;

            yield return null;
        }
        if (hayProcess)
        {
            hayProcess.hayCow = true;
            hayProcess.CollectMilkFromCows();
        }
        if (waterProcess)
        {
           
            waterProcess.waterCow = true;
            waterProcess.CollectMilkFromCows();
        }
        
       
        progressBar.fillAmount = 0f; // �lerleme �ubu�unu tamamen bo�alt
    }
    private void OnProgressBarFilled()
    {
        StartCoroutine(EmptyProgressBar());
       
      //  Debug.Log("�lerleme �ubu�u tamamland�!");
    }

}
