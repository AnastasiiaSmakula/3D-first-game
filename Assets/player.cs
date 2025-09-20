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
    }

    public void HandleMovement(InputAction.CallbackContext context)
    {

        rawInput = context.ReadValue<Vector2>();
    }
}
// vytvor level aj tazsie // skryty kluc 
//rozdel dvere na dve casti 
// skakanie 
// platvofmy 