using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] GameObject horse;
    [SerializeField] GameObject player;
    public Animator animator;
    private bool isHorseMounted = false;
    CharacterMovement characterMovement;
    [SerializeField] Transform harvest;
    [SerializeField] PlayerSo playerSo;
    public void HorseUp() 
    {
        characterMovement = gameObject.GetComponent<CharacterMovement>();

        if (!isHorseMounted)
        {
            characterMovement.HorseSpeed();
            harvest.transform.position = transform.TransformPoint(new Vector3(0, 2.8f, -1f));
            characterMovement.IsIdle = true;
            Vector3 rotation = transform.rotation.eulerAngles;
            
            animator.SetBool("Horse", true);
            animator.SetInteger("Animation_int", 0);
            characterMovement.isHorseMounted = true;
            player.transform.position = transform.TransformPoint(new Vector3(0.14f, 1.72f, -0.35f));
            player.transform.rotation = Quaternion.Euler((rotation.x) + 15f, (rotation.y) + -42, (rotation.z) + -16);
            horse.SetActive(true);

            isHorseMounted = true;
            return;
        }

        if ( isHorseMounted)
        {
            characterMovement.HorseSpeed();
            // characterMovement.MoveSpeed =playerSo.playerSpeed;
            harvest.transform.position = transform.TransformPoint(new Vector3(0, 1.47f, -1f));
            Vector3 rotation = transform.rotation.eulerAngles;
            characterMovement.IsIdle = false;
            characterMovement.isHorseMounted = false;
            horse.SetActive(false);
            animator.SetBool("Horse", false);
            animator.SetFloat("H_Speed", 0f);
            player.transform.position = transform.TransformPoint(Vector3.zero);
            player.transform.rotation = Quaternion.Euler((rotation.x), (rotation.y), (rotation.z));
            isHorseMounted = false;
        }

    }
}
