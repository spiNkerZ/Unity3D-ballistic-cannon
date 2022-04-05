using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieAnimator : MonoBehaviour
{
    [SerializeField]
    private Animator animator;

    public void ZombieAnimatorActive(bool _active)
    {
        animator.enabled = _active;
    }

}
