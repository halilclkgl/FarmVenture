using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class HayProcess : MonoBehaviour
{
    public ProgressBarCow progressBarCow;
 
    public bool hayCow = false;
    public bool control = false;
  
    public MilkControl MilkControl;

    void OnTriggerEnter(Collider other)
    {
       
        if (other.gameObject.tag == "Player" && !control)
        {
            control = true;
            progressBarCow.StartFillProgressBar(this);
        }
       
    }
    public void CollectMilkFromCows()
    {
        MilkControl.CollectMilk();
    }
   
}
