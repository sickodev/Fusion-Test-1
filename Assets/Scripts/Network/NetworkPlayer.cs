using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fusion;

public class NetworkPlayer : NetworkBehaviour, IPlayerLeft
{
    public static NetworkPlayer Local { get; set; }
    public Transform playerModelRoot;
    // Start is called before the first frame update
    void Start()
    {

    }

    public override void Spawned()
    {
        if (Object.HasInputAuthority)
        {
            Local = this;
            //Sets Layer for Local Player
            Utils.SetRenderLayerInChildren(playerModelRoot, LayerMask.NameToLayer("LocalPlayerModel"));

            //Disables Main Camera
            Camera.main.gameObject.SetActive(false);

            Debug.Log("Spawned Local Player");
        }
        else
        {
            //Shuts down Remote Player Camera
            GetComponentInChildren<Camera>().enabled = false;

            //Shuts down Remote Player Audio Listener
            GetComponentInChildren<AudioListener>().enabled = false;

            Debug.Log("Spawned Remote Player");
        }
    }

    public void PlayerLeft(PlayerRef player)
    {
        if (player == Object.HasInputAuthority)
        {
            Runner.Despawn(Object);
        }
    }
}
