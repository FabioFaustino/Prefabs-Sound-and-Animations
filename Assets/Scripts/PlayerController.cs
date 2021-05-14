using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private CharacterController characterController;
    private Animator animator;

    public float moveSpeed = 400;
    public float turnSpeed = 5;

    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
        animator = GetComponentInChildren<Animator>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var horizontal = Input.GetAxis("Horizontal");
        var vertical = Input.GetAxis("Vertical");
        var movement = new Vector3(horizontal, 0, vertical);

        characterController.SimpleMove(movement * Time.deltaTime * moveSpeed);

        animator.SetFloat("Speed", movement.magnitude);

        if(movement.magnitude>0)
        {
            Quaternion newDirection = Quaternion.LookRotation(movement);
            transform.rotation = Quaternion.Slerp(transform.rotation, newDirection,Time.deltaTime * turnSpeed);
        }
    }
}
