using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public GameObject doorObject;
    public float openDuration = 2f;
    public float closeDelay = 2f;

    public bool isOpen = false;
    void OnCollisionStay(Collision collisionInfo)
    {
        if (collisionInfo.gameObject.tag == "Player" && !isOpen)
        {
            doorObject.transform.Rotate(0, 90, 0);
            isOpen = true;
            StartCoroutine(OpenAndCloseDoor());
        }

    }
    private IEnumerator OpenAndCloseDoor()
    {
        yield return new WaitForSeconds(openDuration);
        doorObject.transform.Rotate(0, -90, 0);
        isOpen = false;
    }
}
