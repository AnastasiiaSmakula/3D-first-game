using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.InputSystem;

public class player : MonoBehaviour
{
    [SerializeField]
    private float speed = 0.5f;

    [SerializeField]
    private Vector2 moveInput;

    [SerializeField]
    public bool hasKey = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 move = new Vector3(moveInput.x, 0f, moveInput.y);

        transform.position += move * speed * Time.deltaTime;

    }

    public void HandleMovement(InputAction.CallbackContext context)
    {

        moveInput = context.ReadValue<Vector2>();

        Vector3 cameraRight = Camera.main.transform.right;
        cameraRight.y = 0;
        Vector3 cameraForward = Camera.main.transform.forward;
        cameraForward.y = 0;

        cameraRight.Normalize();
        cameraForward.Normalize();

        //moveInput = cameraRight * moveInput.x + cameraForward * moveInput.y;
    }
}
// vytvor level aj tazsie // skryty kluc 
//rozdel dvere na dve casti 
// skakanie 
// platvofmy 