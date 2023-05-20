using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class SayProcess : MonoBehaviour
{
    public ProgressBarCow progressBarCow;
    public WaterProcess waterProcess;
    public bool hayCow = false;
    public bool control = false;
    private float cowHayBarFillDuration = 10f;

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("�arpt�1231");
        if (other.gameObject.tag == "Player" && !control)
        {
            control = true;
        
            StartCoroutine(FillCowHayBar());
             
            progressBarCow.StartFillProgressBar();
        }
        if (other.gameObject.tag == "Player" && control && waterProcess.control && !hayCow &&!waterProcess.waterCow)
        {
            Debug.Log("denemeee1212");
        }
    }
    private IEnumerator FillCowHayBar()
    {
        yield return new WaitForSeconds(cowHayBarFillDuration);
      
        hayCow = true;
        if (waterProcess.waterCow && hayCow)
        {
            hayCow= false;
            waterProcess.waterCow= false;
            int cowCount = GameObject.FindGameObjectsWithTag("Cow").Length;
            int stok = PlayerPrefs.GetInt("Stok");
            stok += cowCount;
            Debug.Log(stok);
            PlayerPrefs.SetInt("Stok", stok);
            control = false;
            waterProcess.control = false;
        }
    } 
}
