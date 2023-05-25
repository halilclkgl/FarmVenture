using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour, IJoystickObserver
{
    public DayNightCotroller dayNightCotroller;
    [SerializeField] private PlayerSo playerSo;
 
    private float moveSpeed ;
    private CharacterController characterController;
    public Animator animator; 
    public Animator animatorH;
    [SerializeField] private bool isIdle = false;
    private float idleTimer = 0f;
    private float idleTimeThreshold = 2f;
    public bool isHorseMounted=false;
    public List<int> idleAnimations = new List<int>();
    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
        MoveSpeedU();
        if (characterController == null)
        {
            Debug.LogError("Character Controller component is missing on the Player object.");
        }
    }
    public float MoveSpeed 
    {
        get { return moveSpeed; }
        set { moveSpeed = value; }
    }
    public bool IsIdle
    {
        get { return isIdle; }
        set { isIdle = value; }
    }
    public void HorseSpeed() 
    {
        if (isHorseMounted)
        {
           
            MoveSpeedU();
        }
        if (!isHorseMounted)
        {
            MoveSpeedU();
        }
       

    }
    public void MoveSpeedU()
    {
     //   moveSpeed = playerSo.playerSpeed;
        if (dayNightCotroller.GetTime() > 19 || dayNightCotroller.GetTime() < 6)
        {
            moveSpeed = playerSo.playerNightSpeed;
          
        }
        if (dayNightCotroller.GetTime() >= 6 && dayNightCotroller.GetTime() < 19)
        {
            if (!isHorseMounted)
            {
                moveSpeed = playerSo.playerSpeed;
            }
            if (isHorseMounted)
            {
                MoveSpeed = playerSo.horseSpeed;
            }


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
            if (!isHorseMounted)
            {
                animator.SetFloat("Speed_f", 1f);
            }
            // Karakter hareket ettiðinde animasyonlarý oynat
            if (isHorseMounted)
            {
                isIdle = false;
                animator.SetFloat("H_Speed", 1f);
                animator.SetInteger("Animation_int", 0);
                animatorH.SetFloat("Speed_f",1);
            }

            animator.SetInteger("Animation_int", 0);
            isIdle = false;
        }
        else if (isHorseMounted && moveDirection == Vector3.zero) 
        {
            animatorH.SetFloat("Speed_f", 0);
            isIdle = false;
            animator.SetBool("Horse", true);
            animator.SetFloat("H_Speed", 0f);
            animator.SetInteger("Animation_int", 0);
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

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "HOME")
        {

            // Saat 6:00'ý beklemek yerine direkt olarak saat sýfýrlanmasý iþlemi
            if (dayNightCotroller.GetTime() > 19 || dayNightCotroller.GetTime() < 6)
            {
                MoveSpeedU();
                ResetTime();
            }
        }
    }

    void ResetTime()
    {
        dayNightCotroller.TimeSkipt();
       // dayNightCotroller.SetTime(6,0);
    }
}
