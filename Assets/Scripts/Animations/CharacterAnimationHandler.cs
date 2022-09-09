using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimationHandler : MonoBehaviour
{
    Animator animator;
    NetworkInputData networkInputData;
    // Start is called before the first frame update
    private void Awake()
    {
        animator = GetComponentInChildren<Animator>();
    }

    public void PlayerAnimate()
    {
        if (networkInputData.isArmorRotatePressed)
        {
            animator.SetBool("dance", networkInputData.isArmorRotatePressed);
            networkInputData.isArmorRotatePressed = false;
        }
    }
}
