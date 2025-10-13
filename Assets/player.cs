using System;
using System.Data.Common;
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

    [SerializeField]
    private Animator animator;
    [SerializeField]
    private keyManager keyManager;


    public void PickUpKey(int id)
    {
        if (keyManager != null)
        {
            keyManager.ShowKey(id);
        }
        else
        {
            Debug.LogError("link key manager");
        }

    }



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        keyManager = FindAnyObjectByType<keyManager>();

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

        transform.rotation = Quaternion.LookRotation(move);

        transform.position += move * speed * Time.deltaTime;

        currentYVelocity = rigidbody.linearVelocity.y;

        if (Math.Abs(rigidbody.linearVelocity.y) < 0.01)
        {
            isGrounded = true;
            animator.SetBool("IsJumping", false);
            if (Math.Abs(move.z) + Math.Abs(move.x) < 0.01)
            {
                animator.SetBool("IsRunning", false);
            }
            else
            {
                animator.SetBool("IsRunning", true);
            }
            // animator.SetBool("IsRunning", Math.Abs(rigidbody.linearVelocity.z) + Math.Abs(rigidbody.linearVelocity.x) > 0.01);
        }
        else
        {
            //isGrounded = false;
            animator.SetBool("IsJumping", true);
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
            isGrounded = false;

        }
    }

}



// ikonky pre kluce 
// najst 3D model pre kluce 
// canvas do kazdej sceny a aj linkovat


// resetovanie pozicie klucov. 
// a) start pozicia ako vektor pre kluce 
// b)ked hrac spadne tak posunut tie kluuce na startovu poziciu 
// c) odpojit od hraca (aby nebol ich parent) (blabla.parent == null)
// d) key manager nova metoda: reset, a zavolat ako hrac spadne