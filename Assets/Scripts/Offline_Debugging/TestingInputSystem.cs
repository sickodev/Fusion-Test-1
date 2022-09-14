using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TestingInputSystem : MonoBehaviour
{
    private Animator animator;
    private bool isDancing = false;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void Dance(InputAction.CallbackContext context)
    {
        Debug.Log(context.phase);
        if (context.performed)
        {
            StartCoroutine(Animate());
        }

    }

    IEnumerator Animate()
    {
        animator.SetBool("dance", true);
        yield return new WaitForSeconds(10f);
        animator.SetBool("dance", false);
    }
}
