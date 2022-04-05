using UnityEngine;
using System;
using System.Collections;
using System.Linq;

public class CannonTower : Cannon
{
    BallusticCalculate.Data dataTraectory;
    public void OnFire(BallusticCalculate.Data _dataTraectory,Transform _target)
    {
        dataTraectory = _dataTraectory;
        target = _target;
        if (!isReloading) { Fire(); Reloading(); }
    }
    protected override void Fire()
    {
        Ammo ammo = Instantiate(ammoPrefab, shotPoint.position, Quaternion.LookRotation(shotPoint.forward));
        ammo.TransferTargetForAmmo(target);
        ammo.GetRigidBody().velocity = shotPoint.forward * BallusticCalculate.CalculateTrajectory(dataTraectory);

        Destroy(Instantiate(shotEffect.gameObject, shotPointEffects.position, Quaternion.identity), 5);
    }

}
