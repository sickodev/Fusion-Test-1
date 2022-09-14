using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fusion;

public struct NetworkInputData : INetworkInput
{
    public Vector2 movementInput;
    public float rotationInput;
    public NetworkBool isJumpPressed;

    // [Networked(OnChanged = nameof(CharacterAnimationHandler.PlayerAnimate))]
    // public NetworkBool isArmorRotatePressed { get; set; }

    public NetworkBool isFirePressed;
}
