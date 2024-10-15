using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private DefaultPlayerActions defaultPlayerActions;

    private InputAction moveAction;

    private Rigidbody rb;

    private float moveSpeed = 6.0f;

    private void Awake()
    {
        defaultPlayerActions = new DefaultPlayerActions();
        rb = GetComponent<Rigidbody>();
    }

    private void OnEnable()
    {
        moveAction = defaultPlayerActions.Player.Move;
        moveAction.Enable();    
    }

    private void OnDisable()
    {
        moveAction.Disable();
    }

    private void FixedUpdate()
    {
        Vector3 moveDir = moveAction.ReadValue<Vector3>();

        transform.Translate(moveDir.x *  moveSpeed * Time.deltaTime, 0, moveDir.z * moveSpeed * Time.deltaTime);

        Debug.Log(rb.velocity);
    }
}
