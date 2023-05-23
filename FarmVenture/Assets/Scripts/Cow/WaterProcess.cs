using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterProcess : MonoBehaviour
{
    public ProgressBarCow progressBarCow;
    public MilkControl MilkControl;
    public bool waterCow = false;
    public bool control = false;
    // private float cowHayBarFillDuration = 10f;

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
