using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructibleProp : MonoBehaviour, IDamageable
{
    [SerializeField] private float _health;
    [SerializeField] private DropRateManager _dropRateManager;
    public void Damage(float dmg)
    {
        _health -= dmg;
        if (_health <= 0.0f) 
            Die();
    }

    public void Die()
    {
        _dropRateManager.OnDie();
        Destroy(gameObject);
    }
}
