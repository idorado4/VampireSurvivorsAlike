using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public abstract class ProjectileController : MonoBehaviour
{
    [SerializeField] protected Rigidbody2D _rb;
    protected ProjectileStats _stats;

    public ProjectileStats Stats => _stats;
    protected void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.TryGetComponent(out IDamageable iDamageable)) return;
        iDamageable.Damage(_stats.Damage);
        _stats.Pierce--;
        if (_stats.Pierce <= 0)
            Destroy(gameObject);
    }

    public void Config()
    {
        
    }
}