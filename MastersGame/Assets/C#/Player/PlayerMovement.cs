using UnityEngine;
using UnityEngine.Android;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody rb;
    public InputAction playerControls;
    public float moveSpeed = 5f;

    // Variable to store the inputs
    Vector3 moveDirection = Vector3.zero;

    // New input system required to work :)
    private void OnEnable()
    {
        playerControls.Enable();
    }
    // New input system required to work :)
    private void OnDisable()
    {
        playerControls.Disable();
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        // Store input
        moveDirection = playerControls.ReadValue<Vector3>();

        // Update the position
        transform.position = transform.position + new Vector3(moveDirection.x * moveSpeed * Time.deltaTime, 0, moveDirection.z * moveSpeed * Time.deltaTime);

        // TODO: Dash mechanic
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            dash();
        }
    }

    // TODO: dash mechanic
    void dash()
    {
        if (moveDirection.x > 0)
        {
            transform.position = transform.position + new Vector3(5, 0, 0);
        }

        if (moveDirection.x < 0)
        {
            transform.position = transform.position + new Vector3(-5, 0, 0);
        }
    }
}
