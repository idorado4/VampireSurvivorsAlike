using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowWeapon : Weapon
{
    //TODO Hacer una pool de proyectiles
    public override void Use()
    {
        base.Use();
        var angle = Mathf.Atan2(Player.LastMovementDirection.y, Player.LastMovementDirection.x);
        angle *= Mathf.Rad2Deg;
        var newRotation = Quaternion.AngleAxis(angle, Vector3.forward);
        var clone = Instantiate(data.prefab,
            Player.transform.position,
            newRotation);
        clone.Init(data);
        var arrowProjectile = (ArrowProjectile) clone;
        arrowProjectile.SetDirection(Player.LastMovementDirection);
    }
}