using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    private DefaultPlayerActions defaultPlayerActions;

    // Input actions, wasd / shift / space 
    private InputAction moveAction;
    private InputAction sprintAction;
    private InputAction dashAction;

    private Rigidbody rb;

    // Movement variables
    private float moveSpeed = 6.0f;
    private float sprintSpeed = 12.0f;

    // Dashing variables
    private float dashSpeed = 10.0f;
    private float dashTime = 0.05f;
    private float dashCooldown = 1.0f;
    private bool canDash = true;
    private object isDashing = false;

    private void Awake()
    {
        defaultPlayerActions = new DefaultPlayerActions();
        rb = GetComponent<Rigidbody>();
    }

    private void OnEnable()
    {
        moveAction = defaultPlayerActions.Player.Move;
        moveAction.Enable();
        sprintAction = defaultPlayerActions.Player.Sprint;
        sprintAction.Enable();
        dashAction = defaultPlayerActions.Player.Dash;
        dashAction.Enable();
    }

    private void OnDisable()
    {
        moveAction.Disable();
        sprintAction.Disable();
        dashAction.Disable();
    }

    private void FixedUpdate()
    {
        Vector3 moveDir = moveAction.ReadValue<Vector3>();
        moveDir = Vector3.ClampMagnitude(moveDir, 1.0f);

        // Check for sprinting else normal movement
        if (sprintAction.IsPressed())
        {
            Sprint(moveDir);
        }
        else
        {
            transform.Translate(moveDir.x * moveSpeed * Time.deltaTime, 0, moveDir.z * moveSpeed * Time.deltaTime);
        }

        // Check for dash
        if (dashAction.IsPressed() && canDash)
        {
            StartCoroutine(Dash(moveDir));
        }
        
    }

    // Space = dash
    private IEnumerator Dash(Vector3 moveDir)
    {
        //TODO
        Debug.Log("Dash!");
        canDash = false;
        isDashing = true;
        rb.velocity = new Vector3(moveDir.x * dashSpeed, 0, moveDir.z * dashSpeed);
        yield return new WaitForSeconds(dashTime);
        isDashing = false;
        yield return new WaitForSeconds(dashCooldown);
        canDash = true;
    }

    // Shift = sprint
    private void Sprint(Vector3 moveDir)
    {
        transform.Translate(moveDir.x * sprintSpeed * Time.deltaTime, 0, moveDir.z * sprintSpeed * Time.deltaTime);
    }
}
