using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    public Image fillImage;
    public float fillSpeed = 2f;
    private float currentFill = 0f;
 //   private bool isFilled = false;

    private void Start()
    {
        ResetProgressBar();
    }

    public void UpdateFillAmount(float fillAmount)
    {
        fillImage.fillAmount = fillAmount;
    }

    private void OnProgressBarFilled()
    {
        // Ýlerleme çubuðu tamamlandýðýnda yapýlacak iþlemler
        Debug.Log("Ýlerleme çubuðu tamamlandý!");
    }

    public void ResetProgressBar()
    {
        currentFill = 0f;
      //  isFilled = false;
        UpdateFillAmount(currentFill);
    }
}
