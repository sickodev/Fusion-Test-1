using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TestingInputSystem : MonoBehaviour
{
    private Animator animator;
    private PlayerControls playerControls;

    private void Awake()
    {
        animator = GetComponentInChildren<Animator>();
        playerControls = new PlayerControls();
    }

    private void Update()
    {
        Vector2 inputVector = playerControls.Controls.Movement.ReadValue<Vector2>();
        transform.position += new Vector3(inputVector.x, 0, inputVector.y) * 0.02f;
    }

    public void Dance(InputAction.CallbackContext context)
    {
        Debug.Log(context.phase);
        if (context.performed)
        {
            StartCoroutine(Animate());
        }

    }

    public void Movement(InputAction.CallbackContext context)
    {
        Debug.Log(context);
        Vector2 inputVector = context.ReadValue<Vector2>();
        transform.position += new Vector3(inputVector.x, 0, inputVector.y) * 0.02f;
    }

    IEnumerator Animate()
    {
        animator.SetBool("dance", true);
        yield return new WaitForSeconds(10f);
        animator.SetBool("dance", false);
    }
}
