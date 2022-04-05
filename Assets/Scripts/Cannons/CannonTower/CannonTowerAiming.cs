using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonTowerAiming : MonoBehaviour
{
    [SerializeField] CannonTower cannonTower;
    [SerializeField] Transform tower;
    [SerializeField] Transform towerMuzzle;

    [SerializeField] [Range(0, 5)] float dealyAttackAfterCatch;
    [SerializeField] [Range(1, 5)] float speedTowerRotate;
    [SerializeField] [Range(1, 100)] float speedMuzzleRotate;
    [SerializeField] [Range(5, 500)] float enemyDetectedDist;
    Transform target;
    float timeCatchTarget;

    private void Start()
    {
        target = GameManager.Singleton.enemy.transform;
    }
    private void Update()
    {
        CannonTowerSearchEnemy();
    }
    protected void CannonTowerSearchEnemy()
    {
        if ((target.position - transform.position).magnitude < enemyDetectedDist)
        {
            AimToTarget(target);
        }
        else
        {
            TowerRotate();
        }

        MuzzleRotate();
    }

    void TowerRotate()
    {
        tower.Rotate(0, speedTowerRotate, 0);
    }
    void MuzzleRotate()
    {
        towerMuzzle.localEulerAngles = new Vector3(Mathf.PingPong(Time.time * speedMuzzleRotate , 50) -70, 0, 0);
    }
    void AimToTarget(Transform _target)
    {
        Vector3 focusOnTarget = _target.position - tower.position;
        tower.rotation = Quaternion.LookRotation(focusOnTarget, Vector3.up);

        if (!cannonTower.isReloading && Time.time > timeCatchTarget)
        {
            cannonTower.OnFire(new BallusticCalculate.Data
            {
                angle =  towerMuzzle.localEulerAngles.x,
                fromTo = target.position - towerMuzzle.position
            }, target);

            timeCatchTarget = Time.time + dealyAttackAfterCatch;
        }
    }

}
