using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] GameObject horse;
    [SerializeField] GameObject player;
    public Animator animator;
    private bool isHorseMounted = false;

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.H) && !isHorseMounted)
        {
            Debug.Log("bindi");
            animator.SetBool("horse", true);
            player.transform.position = new Vector3(0.14f, 1.72f, -0.35f);
            player.transform.rotation = Quaternion.Euler(15f, -42, -16);
            horse.SetActive(true);
            isHorseMounted = true;
        }

        if (Input.GetKeyUp(KeyCode.F) && isHorseMounted)
        {
            Debug.Log("indi");
            horse.SetActive(false);
            animator.SetBool("horse", false);
            player.transform.position = Vector3.zero;
            player.transform.rotation = Quaternion.identity;
            isHorseMounted = false;
        }
    }
}
