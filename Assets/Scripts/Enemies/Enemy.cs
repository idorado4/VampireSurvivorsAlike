using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, IDamageable
{
    [SerializeField] protected EnemyStats stats;
    [SerializeField] protected DropRateManager dropRateManager;

    private Transform _playerTransform;
    private float _health;
    protected float _speed;
    protected int _damage;


    protected void Update()
    {
        Move();
    }

    protected void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("trigger enter");
        if (!other.TryGetComponent(out IDamageable iDamageable)) return;
        StartCoroutine(nameof(DamagePlayer), iDamageable);
    }

    protected void OnTriggerExit2D(Collider2D other)
    {
        Debug.Log("trigger exit");
        if (!other.TryGetComponent(out IDamageable iDamageable)) return;
        StopCoroutine(nameof(DamagePlayer));
    }

    public virtual void Init(Transform playerTransform)
    {
        _playerTransform = playerTransform;
        _health = stats.health;
        _speed = stats.speed;
        _damage = stats.damage;
    }

    protected void Move()
    {
        if (!ReferenceEquals(_playerTransform, null))
        {
            transform.position =
                Vector3.MoveTowards(transform.position, _playerTransform.position, _speed * Time.deltaTime);
        }
    }

    public void Damage(float damage)
    {
        _health--;
        if (_health <= 0) Die();
    }

    public void Die()
    {
        dropRateManager.OnDie();
        Destroy(gameObject);
    }

    private IEnumerator DamagePlayer(IDamageable damageable)
    {
        while (true)
        {
            damageable.Damage(_damage);
            yield return new WaitForSecondsRealtime(1.0f);
        }
    }
}