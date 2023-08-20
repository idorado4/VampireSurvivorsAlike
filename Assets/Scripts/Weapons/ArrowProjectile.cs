using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowProjectile : Projectile
{
    public void SetDirection(Vector3 direction)
    {
        _rb.velocity = speed * direction;
    }
}