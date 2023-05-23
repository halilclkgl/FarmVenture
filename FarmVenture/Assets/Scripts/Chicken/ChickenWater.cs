using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickenWater : MonoBehaviour
{
    public ProgressBarChicken ProgressBarChicken;

    public bool waterChicken = false;
    public bool control = false;

    public EggControl eggControl;

    void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "Player" && !control)
        {
            control = true;

            //StartCoroutine(FillCowHayBar());

            ProgressBarChicken.StartFillProgressBar(this);
        }

    }
    public void CollectEggFromChick()
    {
        eggControl.CollectEgg();

    }
}
