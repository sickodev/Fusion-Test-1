using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fusion;

public class CharacterMovementHandler : NetworkBehaviour
{
    Vector2 viewInput;

    Camera localCamera;
    float cameraRotationX = 0;
    private Animator localAnimator;


    NetworkCharacterControllerPrototypeCustom networkCharacterControllerPrototypeCustom;

    private void Awake()
    {
        networkCharacterControllerPrototypeCustom = GetComponent<NetworkCharacterControllerPrototypeCustom>();
        localCamera = GetComponentInChildren<Camera>();
        localAnimator = GetComponentInChildren<Animator>();
        viewInput = Vector2.zero;
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        cameraRotationX += viewInput.y * Time.deltaTime;
        cameraRotationX = Mathf.Clamp(cameraRotationX, -90, 90);

        localCamera.transform.localRotation = Quaternion.Euler(cameraRotationX, 0, 0);
    }

    public void SetViewInputVector(Vector2 viewInput)
    {
        this.viewInput = viewInput;

    }

    public override void FixedUpdateNetwork()
    {
        if (GetInput(out NetworkInputData networkInputData))
        {
            //Rotate
            networkCharacterControllerPrototypeCustom.Rotate(networkInputData.rotationInput);

            //Move
            Vector3 moveDirection = networkInputData.movementInput.y * transform.forward + networkInputData.movementInput.x * transform.right;
            moveDirection.Normalize();

            networkCharacterControllerPrototypeCustom.Move(moveDirection);

            //Jump
            if (networkInputData.isJumpPressed)
            {
                networkCharacterControllerPrototypeCustom.Jump();
            }

            //Animate
            if (networkInputData.isArmorRotatePressed)
            {
                localAnimator.SetBool("dance", networkInputData.isArmorRotatePressed);
            }
        }
    }


}
