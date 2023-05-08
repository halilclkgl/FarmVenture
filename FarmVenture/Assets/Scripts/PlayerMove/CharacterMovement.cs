using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour, IJoystickObserver
{
    public float moveSpeed = 5f;
    private CharacterController characterController;
    public Animator animator;
    private bool isIdle = false;
    private float idleTimer = 0f;
    private float idleTimeThreshold = 2f;
    public List<int> idleAnimations = new List<int>() ;
    private void Awake()
    {
        characterController = GetComponent<CharacterController>();

        if (characterController == null)
        {
            Debug.LogError("Character Controller component is missing on the Player object.");
        }
    }

    public void OnJoystickInput(Vector2 direction)
    {
        if (characterController == null)
        {
            Debug.LogError("Character Controller component is missing on the Player object.");
            return;
        }

        Vector3 moveDirection = new Vector3(direction.x, 0f, direction.y);
        moveDirection.Normalize();

        if (moveDirection != Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(moveDirection, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, 10f);

            // Karakter hareket ettiðinde animasyonlarý oynat
            animator.SetFloat("Speed_f", 1f);
            animator.SetInteger("Animation_int", 0);
            isIdle = false;
        }
        else
        {
            // Karakter durduðunda idle animasyonunu oynat
            animator.SetFloat("Speed_f", 0f);

            if (!isIdle)
            {
                idleTimer += Time.deltaTime;
                if (idleTimer >= idleTimeThreshold)
                {
                    PlayRandomIdleAnimation();
                    idleTimer = 0f;
                }
            }
        }

        characterController.Move(moveDirection * moveSpeed * Time.deltaTime);
    }

    private void PlayRandomIdleAnimation()
    {
        if (idleAnimations.Count == 0)
        {
            return;
        }

        // Rastgele bir idle animasyonu seçin
        int randomAnimation = idleAnimations[Random.Range(0, idleAnimations.Count)];

        // Seçilen animasyonu oynatýn
        animator.SetInteger("Animation_int", randomAnimation);
        isIdle = true;
    }
}
