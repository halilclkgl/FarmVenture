using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMovement : MonoBehaviour
{
    public Transform shopWaypoint;
    public Transform roadSide;
    public float waitTime = 1f;
    public float moveSpeed = 5f;

    //private bool reachedShopWaypoint = false;
    private void Awake()
    {
        shopWaypoint = GameObject.FindGameObjectWithTag("Way1").transform;
        roadSide = GameObject.FindGameObjectWithTag("Way2").transform;
        StartCoroutine(DriveRoutine());
    }

    private IEnumerator DriveRoutine()
    {

        yield return StartCoroutine(MoveTowardsWaypoint(shopWaypoint.position));

       // reachedShopWaypoint = true;

        yield return new WaitForSeconds(waitTime);

        yield return StartCoroutine(MoveTowardsWaypoint(roadSide.position));

        gameObject.SetActive(false);
        MoveCoroutine();

        // Objeyi tekrar aktif hale getir


    }

    private IEnumerator MoveTowardsWaypoint(Vector3 targetPosition)
    {
        while (transform.position != targetPosition)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
            yield return null;
        }
    }
    public void MoveToDestination()
    {
        StartCoroutine(DriveRoutine());

    }
    private void MoveCoroutine()
    {
        transform.position = new Vector3(11.03f, 1f, 34.54f);

    }
   
}
