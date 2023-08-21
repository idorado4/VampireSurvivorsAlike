using System;
using UnityEngine;


public class Projectile : MonoBehaviour
{
    protected Rigidbody2D _rb;

    protected int damage;
    protected float dmgRange;
    protected float speed;
    protected float pierce;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    public virtual void Init(WeaponDataSO data)
    {
        damage = data.damage;
        speed = data.speed;
        pierce = data.pierce;
        dmgRange = data.dmgRange;
    }

    protected void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("trigger enter");
        if (!other.TryGetComponent(out IDamageable iDamageable)) return;
        iDamageable.Damage(damage);
        pierce--;
        if (pierce <= 0)
            Destroy(gameObject);
    }
}