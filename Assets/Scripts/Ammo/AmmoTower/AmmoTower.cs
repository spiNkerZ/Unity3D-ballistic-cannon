using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoTower : Ammo
{
    [SerializeField] bool preemption;
    [SerializeField] [Range(0, 1)] float proActiveSpeed;
    [SerializeField] [Range(1, 100)] float proActiveFlyHeight;
    Vector3 startVector;
    float elapsedTime = 0.0f;
    public void SetActivePreemptionMode(bool _active)
    {
        preemption = _active;
    }

    private void Start()
    {
        startVector = transform.position;
        if (preemption) rigidBody.isKinematic = true;
    }

    protected override void Update()
    {
        base.Update();

        if (preemption)
        {
            elapsedTime += 0.01f * proActiveSpeed;
            Vector3 currectVector = target.transform.forward * GameManager.Singleton.enemy.speed;
            transform.position = ProactiveCalculate.TraectroyCalculate(startVector, target.position + currectVector, proActiveFlyHeight, elapsedTime);
        }
    }
}
