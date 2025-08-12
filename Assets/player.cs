using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.InputSystem;

public class player : MonoBehaviour
{
    [SerializeField]
    private float speed = 0.5f;

    [SerializeField]
    private Vector2 moveInput;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // transform.position = new Vector3(transform.position.x + 1 / speedEfekt * Time.deltaTime, transform.position.y, transform.position.z);

        Vector3 move = new Vector3(moveInput.x, 0f, moveInput.y);

        transform.position += move * speed * Time.deltaTime;

    }

    public void HandleMovement(InputAction.CallbackContext context)
    {

        moveInput = context.ReadValue<Vector2>();

    }
}
// menit poziciu v zavislosti od stlaceneho gombika 