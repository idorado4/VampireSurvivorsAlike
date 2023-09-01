using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowWeapon : WeaponController
{
    protected override void Shoot()
    {
        var clone = Instantiate((ArrowProjectile)_stats.Prefab);
        clone.SetDirection(Vector3.right);
    }
}