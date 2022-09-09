using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterInputHandler : MonoBehaviour
{

    Vector2 moveInputVector = Vector2.zero;
    Vector2 viewInputVector = Vector2.zero;
    bool isJumpBtnPressed = false;
    bool isArmorRotateBtnPressed = false;

    Animator localAnimator;

    CharacterMovementHandler characterMovementHandler;

    private void Awake()
    {
        characterMovementHandler = GetComponent<CharacterMovementHandler>();
    }

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        //View
        viewInputVector.x = Input.GetAxis("Mouse X");
        viewInputVector.y = Input.GetAxis("Mouse Y") * -1;//inverted

        characterMovementHandler.SetViewInputVector(viewInputVector);

        //Move
        moveInputVector.x = Input.GetAxisRaw("Horizontal");
        moveInputVector.y = Input.GetAxisRaw("Vertical");

        //Jump
        isJumpBtnPressed = Input.GetButtonDown("Jump");

        //Animation
        isArmorRotateBtnPressed = Input.GetKey(KeyCode.R);
    }

    public NetworkInputData GetNetworkInput()
    {
        NetworkInputData networkInputData = new NetworkInputData();

        //View Data
        networkInputData.rotationInput = viewInputVector.x;

        //Move Data
        networkInputData.movementInput = moveInputVector;

        //Jump Data
        networkInputData.isJumpPressed = isJumpBtnPressed;

        //Animation
        networkInputData.isArmorRotatePressed = isArmorRotateBtnPressed;

        return networkInputData;
    }
}
