using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopRunning : MonoBehaviour
{
    private Animator anim;
    private static readonly int IsRunning = Animator.StringToHash("IsRunning");

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    public void StopAnimation()
    {
        anim.SetBool(IsRunning, false);
        GameManager.Instance.player.canMove = true;
    }
}
