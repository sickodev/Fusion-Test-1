using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocalCameraHandler : MonoBehaviour
{
    public Transform cameraAnchorPoint;

    Vector2 viewInput;
    float cameraRotationX, cameraRotationY;
    Camera localCamera;
    NetworkCharacterControllerPrototypeCustom networkCharacterControllerPrototypeCustom;

    // Start is called before the first frame update

    private void Awake()
    {
        localCamera = GetComponent<Camera>();
        networkCharacterControllerPrototypeCustom = GetComponent<NetworkCharacterControllerPrototypeCustom>();
    }
    void Start()
    {
        //Detach Camera on Local
        if (localCamera.enabled)
            localCamera.transform.parent = null;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (cameraAnchorPoint == null)
            return;
        if (!localCamera.enabled)
            return;

        localCamera.transform.position = cameraAnchorPoint.position;

        cameraRotationX += viewInput.y * Time.deltaTime * networkCharacterControllerPrototypeCustom.viewUpDownRotationSpeed;
        cameraRotationX = Mathf.Clamp(cameraRotationX, -90, 90);

        cameraRotationY += viewInput.x * Time.deltaTime * networkCharacterControllerPrototypeCustom.viewUpDownRotationSpeed;

        //Apply Rotation
        localCamera.transform.rotation = Quaternion.Euler(cameraRotationX, cameraRotationY, 0);

    }

    public void SetViewInputVector(Vector2 viewInput)
    {
        this.viewInput = viewInput;
    }
}
