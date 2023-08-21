using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, IDamageable
{
    [SerializeField] protected EnemyStatsSO statsSo;
    [SerializeField] protected DropRateManager dropRateManager;

    private Transform _playerTransform;
    private float _health;
    protected float _speed;
    protected int _damage;

    public delegate void EnemyKilled();

    public EnemyKilled OnEnemyKilled;

    protected void Update()
    {
        Move();
    }

    protected void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.TryGetComponent(out IDamageable iDamageable)) return;
        StartCoroutine(nameof(DamagePlayer), iDamageable);
    }

    protected void OnTriggerExit2D(Collider2D other)
    {
        if (!other.TryGetComponent(out IDamageable iDamageable)) return;
        StopCoroutine(nameof(DamagePlayer));
    }

    public virtual void Init(Transform playerTransform)
    {
        _playerTransform = playerTransform;
        _health = statsSo.maxHealth;
        _speed = statsSo.speed;
        _damage = statsSo.damage;
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
        OnEnemyKilled?.Invoke();
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