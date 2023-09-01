using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowProjectile : ProjectileController
{
    public void SetDirection(Vector3 direction)
    {
       _rb.velocity = _stats.Speed * direction;
        
    }
}