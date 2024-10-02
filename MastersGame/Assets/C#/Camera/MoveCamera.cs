using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    private float yaw = 0;
    private float pitch = 0;
    [SerializeField] float cameraSpeed;
    [SerializeField] float movementSpeed;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        // Camera panning
        yaw += Input.GetAxis("Mouse X") * cameraSpeed;
        pitch -= Input.GetAxis("Mouse Y") * cameraSpeed;

        pitch = Mathf.Clamp(pitch, -50, 50);

        transform.eulerAngles = new Vector3(pitch, yaw, 0);

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

        // Up Down
        if (Input.GetKey(KeyCode.Q))
        {
            transform.Translate(Vector3.up * movementSpeed * Time.deltaTime);   
        }
        if (Input.GetKey(KeyCode.E))
        {
            transform.Translate(Vector3.down * movementSpeed * Time.deltaTime); 
        }

        
    }
}
