using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterProcess : MonoBehaviour
{
    public ProgressBarCow progressBarCow;
    public SayProcess sayProcess;
    public bool waterCow = false;
    public bool control = false;
    private float cowHayBarFillDuration = 10f;

    void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "Player" && !control)
        {
            control = true;

            StartCoroutine(FillCowHayBar());

            progressBarCow.StartFillProgressBar();
        }
    }
    private IEnumerator FillCowHayBar()
    {
        yield return new WaitForSeconds(cowHayBarFillDuration);
      
        waterCow = true;
        if (waterCow && sayProcess.hayCow)
        {
            sayProcess.hayCow = false;
            waterCow = false;
            int cowCount = GameObject.FindGameObjectsWithTag("Cow").Length;
            int stok = PlayerPrefs.GetInt("Stok");
            stok+=cowCount;
            Debug.Log(stok);
            PlayerPrefs.SetInt("Stok",stok);
            control = false;
            sayProcess.control = false ;
        }
    }
}
