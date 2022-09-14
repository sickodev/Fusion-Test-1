using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DanceInput : MonoBehaviour
{
    public Animator mAnim;
    [SerializeField] bool isPressed = false;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        isPressed = Input.GetButton("Fire1");
        mAnim.SetBool("dance",isPressed);
    }
}
