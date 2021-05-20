using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/**
 * Saltar
 * apanhar merdas do chao
 * Backpack ????????
 * Agachar
 */


public class PlayerController : MonoBehaviour
{
    private CharacterController characterController;
    private Animator animator;

    public float forwardMoveSpeed = 7.5f;


    public float backMoveSpeed = 3f;
    public float turnSpeed = 15;

    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
        animator = GetComponentInChildren<Animator>();

        Cursor.lockState = CursorLockMode.Locked;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }


    // Update is called once per frame
    void Update()
    {
        var horizontal = Input.GetAxis("Mouse X");
        var vertical = Input.GetAxis("Vertical");
        var movement = new Vector3(horizontal, 0, vertical);


        animator.SetFloat("Speed", vertical);

        transform.Rotate(Vector3.up, horizontal * turnSpeed * Time.deltaTime);

        if(vertical != 0)
        {
            float moveSpeed = vertical > 0 ? forwardMoveSpeed : backMoveSpeed;

            characterController.SimpleMove(transform.forward * moveSpeed * vertical);
        }
    }
}
