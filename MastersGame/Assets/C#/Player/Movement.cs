using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] float movementSpeed;
    [Range(1, 500)]
    [SerializeField] float jumpForce;
    [SerializeField] Rigidbody rb;
    private bool canJump;

    // Start is called before the first frame update
    void Start()
    {
        canJump = true;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        // Camera Movement
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

        // Check speed up
        if (Input.GetKey(KeyCode.LeftShift))
        {
            transform.Translate(movement * movementSpeed * 2 * Time.deltaTime);
        }
        else
        {
            transform.Translate(movement * movementSpeed * Time.deltaTime);
        }

        if (Input.GetKeyDown(KeyCode.Space) && canJump)
        {
            rb.AddForce(0, jumpForce, 0);
            canJump = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
        {
            canJump = true;
        }
    }
}
