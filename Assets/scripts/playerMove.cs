using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class playerMove : MonoBehaviour
{
    public float moveSpeed = 2, runSpeed = 4, jumpPower = 10;
    public float mouse_x = 10, mouse_y = 10;

    private Rigidbody rbody;

    public float max_angle = 70, min_angle = -60;

    public Transform camer;

    private Animator animator;

    void Start()
    {
        rbody = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }
    bool jumpCommand = false;
    float angle = 0;

    void Update()
    {
        jumpCommand |= Input.GetButtonDown("Jump");
        var mouseInput = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
        transform.rotation *= Quaternion.Euler(0, mouseInput.x * mouse_x * Time.deltaTime, 0);
        angle = Mathf.Clamp(angle - mouseInput.y * mouse_y * Time.deltaTime, -max_angle, -min_angle);
        camer.localRotation = Quaternion.Euler(angle, 0, 0);
    }

    private void FixedUpdate()
    {
        var motionInput = transform.rotation * new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
        {

            animator.SetBool("IsWalking", true);

        }
        else
        {

            animator.SetBool("IsWalking", false);

        }
        motionInput.x += rbody.velocity.x;
        motionInput.z += rbody.velocity.z;
        var speed = Input.GetButton("Fire3") ? runSpeed : moveSpeed;
        if (Input.GetButton("Fire3") == true)
        {

            animator.SetBool("IsRunning", true);

        }
        else
        {

            animator.SetBool("IsRunning", false);

        }
        motionInput = Vector3.ClampMagnitude(motionInput, speed);

        motionInput.y = rbody.velocity.y;
        if (jumpCommand)
        {
            jumpCommand = false;
            motionInput.y = jumpPower;
        }
        rbody.velocity = motionInput;
    }
}