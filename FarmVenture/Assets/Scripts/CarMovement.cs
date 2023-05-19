using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMovement : MonoBehaviour
{
    public Transform shopWaypoint;
    public Transform roadSide;
    public float waitTime = 3f;
    public float moveSpeed = 5f;

    private bool reachedShopWaypoint = false;
    private void Awake()
    {
        shopWaypoint = GameObject.FindGameObjectWithTag("Way1").transform;
        roadSide = GameObject.FindGameObjectWithTag("Way2").transform;
        StartCoroutine(deneme());
    }

    private IEnumerator deneme()
    {

        yield return StartCoroutine(MoveTowardsWaypoint(shopWaypoint.position));

        reachedShopWaypoint = true;

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
        StartCoroutine(deneme());

    }
    private void MoveCoroutine()
    {
        transform.position = new Vector3(13.3f, 0.61f, 22.71f);

    }
    private void Update()
    {
        if (reachedShopWaypoint)
        {
            // Yapýlacak iþlemler
        }
    }
}
