using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickenFeed : MonoBehaviour
{
    public ProgressBarChicken ProgressBarChicken;

    public bool feedChicken = false;
    public bool control = false;

    public EggControl eggControl;

    void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "Player" && !control)
        {
            control = true;
            ProgressBarChicken.StartFillProgressBar(this);
        }

    }
    public void CollectEggFromChick()
    {
        eggControl.CollectEgg();
    }
}
