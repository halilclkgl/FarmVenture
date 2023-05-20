using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CowMovement : MonoBehaviour
{
    public Transform[] waypoints;
    public Animator animator;
    public float eatDuration = 20f;

    private int currentWaypointIndex = 0;
    private bool isEating = false;
    private bool isIdle = false;
    public string Name;
    private void Start()
    {
        waypoints = GameObject.FindGameObjectsWithTag(Name)
        .Select(obj => obj.transform)
        .ToArray();
        if (waypoints.Length == 0)
        {
            Debug.LogError("Waypoints not set!");
            return;
        }

        animator = GetComponent<Animator>();
        SetNextWaypoint();
    }

    private void Update()
    {
        if (!isEating && !isIdle)
        {
            MoveToWaypoint();
        }
    }

    private void MoveToWaypoint()
    {
        float rotationSpeed = 5f;
        Vector3 targetPosition = waypoints[currentWaypointIndex].position;

        if (targetPosition != transform.position)
        {
            Quaternion targetRotation = Quaternion.LookRotation(targetPosition - transform.position);
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }

        float speed = animator.GetFloat("Speed_f");

        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

        if (transform.position == targetPosition)
        {
            if (waypoints[currentWaypointIndex].CompareTag("Food") || waypoints[currentWaypointIndex].CompareTag("Water"))
            {
                StartCoroutine(StartEating());
            }
            else if (waypoints[currentWaypointIndex].CompareTag("Idle"))
            {
                StartCoroutine(StartIdle());
            }
            else
            {
                SetNextWaypoint();
            }
        }
    }

    private void SetNextWaypoint()
    {
        if (waypoints.Length == 0)
        {
            return;
        }

        currentWaypointIndex = Random.Range(0, waypoints.Length);
    }

    private IEnumerator StartEating()
    {
        isEating = true;
        animator.SetBool("Eat_b", true);
        animator.SetFloat("Speed_f", 0f);

        yield return new WaitForSeconds(eatDuration);

        animator.SetBool("Eat_b", false);
        animator.SetFloat("Speed_f", 0.3f);
        isEating = false;
        SetNextWaypoint();
    }
    private IEnumerator StartIdle()
    {
        isIdle = true;

        animator.SetFloat("Speed_f", 0f);

        yield return new WaitForSeconds(eatDuration);

        animator.SetBool("Eat_b", false);
        animator.SetFloat("Speed_f", 0.3f);
        isIdle = false;
        SetNextWaypoint();
    }
}
