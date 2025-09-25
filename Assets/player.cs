using System;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.InputSystem;

public class player : MonoBehaviour
{
    [SerializeField]
    private float speed = 0.5f;

    [SerializeField]
    private Vector3 moveInput;

    [SerializeField]
    public bool hasKey = false;

    [SerializeField]
    public Vector2 rawInput;

    public Rigidbody rigidbody;

    public int JumpForce;

    [SerializeField]
    private bool isGrounded = true;

    [SerializeField]
    private float currentYVelocity = 0f;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 cameraRight = Camera.main.transform.right;
        //cameraRight.y = 0;
        Vector3 cameraForward = Camera.main.transform.forward;
        //cameraForward.y = 0;

        cameraRight.Normalize();
        cameraForward.Normalize();

        moveInput = cameraRight * rawInput.x + cameraForward * rawInput.y;

        Vector3 move = new Vector3(moveInput.x, 0, moveInput.z);

        transform.position += move * speed * Time.deltaTime;

        currentYVelocity = rigidbody.linearVelocity.y;

        if (Math.Abs(rigidbody.linearVelocity.y) < 0.01)
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }

        if (rigidbody.position.y < -7)
        {
            Vector3 start = new Vector3(1, 1, 1);
            transform.position = start;

        }
    }

    public void HandleMovement(InputAction.CallbackContext context)
    {
        rawInput = context.ReadValue<Vector2>();
    }

    // Look at velocities of the rigidbody
    // If sa nehibe vertikalne (y)
    // Novy state / premennu na to vediet kedy uz sa mozeme hybat

    public void Jump(InputAction.CallbackContext context)
    {
        if (!context.performed) return;

        if (isGrounded)
        {

            Vector3 force = Vector3.up * JumpForce;
            rigidbody.AddForce(force);
        }
    }
}

//novy level kde budu platformy 
//vytvorit level kde najpv musime nazbierat viac veci napr 2 kluce 
