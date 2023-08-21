using System;
using UnityEngine;


public class Projectile : MonoBehaviour
{
    protected Rigidbody2D _rb;

    protected float damage;
    protected float dmgRange;
    protected float speed;
    protected float pierce;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    public virtual void Init(Weapon.ProjectileStats stats, PlayerStats playerStats)
    {
        damage = stats.damage * playerStats.AttackDmg;
        speed = stats.speed * playerStats.ProjectileSpeed;
        pierce = stats.pierce;
        dmgRange = stats.dmgRange;
    }

    protected void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.TryGetComponent(out IDamageable iDamageable)) return;
        iDamageable.Damage(damage);
        pierce--;
        if (pierce <= 0)
            Destroy(gameObject);
    }
}