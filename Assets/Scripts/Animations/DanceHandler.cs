using System.Collections;
using System.Collections.Generic;
using Fusion;
using UnityEngine;

public class DanceHandler : NetworkBehaviour
{

    [Networked(OnChanged = nameof(OnDanceChanged))]
    public bool isDancing { get; set; }

    public Animator animator;
    float lastTimeDanced = 0.0f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    public override void FixedUpdateNetwork()
    {
        if (GetInput(out NetworkInputData networkInputData))
        {
            if (networkInputData.isFirePressed)
                Dance();
        }
    }

    IEnumerator DanceEffect()
    {
        isDancing = true;
        animator.SetBool("dance", isDancing);

        yield return new WaitForSeconds(0.09f);

        isDancing = false;
    }

    void Dance()
    {
        if (Time.time - lastTimeDanced < 0.15f)
            return;

        StartCoroutine(nameof(DanceEffect));

        lastTimeDanced = Time.time;
    }

    public static void OnDanceChanged(Changed<DanceHandler> changed)
    {
        Debug.Log($"{Time.time} on Dance Changed Value {changed.Behaviour.isDancing}");
        bool isDancingCurrent = changed.Behaviour.isDancing;

        //Load the old value
        changed.LoadOld();

        bool isDancingOld = changed.Behaviour.isDancing;

        // if (isDancingCurrent && !isDancingOld)
        // {
        //     Debug.Log($"Current Value: {isDancingCurrent} \n Old Value: {isDancingOld}");
        //     changed.Behaviour.OnDanceRemote();
        // }

        if (changed.Behaviour.isDancing)
        {
            changed.Behaviour.animator.SetFloat("dance", 1);
            Debug.Log(changed.Behaviour.isDancing);
        }
        else
        {
            changed.Behaviour.animator.SetFloat("dance", 0);
        }
        Debug.Log(isDancingCurrent + " " + isDancingOld + " " + changed.Behaviour.isDancing);
    }

    void OnDanceRemote()
    {
        if (!Object.HasInputAuthority)
        {
            animator.SetBool("dance", isDancing);
        }
    }
}
