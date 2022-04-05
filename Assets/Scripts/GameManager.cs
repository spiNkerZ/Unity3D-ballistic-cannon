using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Singleton;
    public EnemyAI enemy;

    private void Awake()
    {
        Singleton = this;
    }

}
