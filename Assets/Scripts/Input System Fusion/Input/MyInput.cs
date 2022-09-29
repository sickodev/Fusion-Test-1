using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fusion;

enum MyButtons
{
   Dance = 0,
   Forward = 1,
   Backward = 2,
   Left = 3,
   Right = 4

}
public struct MyInput : INetworkInput
{
    public NetworkButtons buttons;
    public Vector2 movement;

}
