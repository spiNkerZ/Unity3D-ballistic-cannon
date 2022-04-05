using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

public class ZombieAI : EnemyAI, IDamaged
{
    [SerializeField] ZombieAnimator zombieAnimator;

    public override void OnActiveZombieMove(bool _active)
    {
        base.OnActiveZombieMove(_active);
        zombieAnimator.ZombieAnimatorActive(_active);
    }

    public override void Damage()
    {
        Debug.Log("ZOMBIE DAMAGE");
    }

}


