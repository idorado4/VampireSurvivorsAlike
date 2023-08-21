using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour, IDamageable
{
    [SerializeField] private PlayerStatsSO stats;

    public float _health;
    private float _currentSpeed;
    private float _currentRecovery;
    private float _currentProjectileSpeed;
    private float _currentMight;

    [Header("Leveling")] [SerializeField] private int _experience;
    [SerializeField] private int _level = 1;
    [SerializeField] private int _experienceCap = 100;
    [SerializeField] private int _experienceCapIncrease = 100;

    private void Awake()
    {
        _health = stats.health;
        _currentSpeed = stats.speed;
        _currentRecovery = stats.recovery;
        _currentProjectileSpeed = stats.projectileSpeed;
        _currentMight = stats.might;
    }

    public void IncreaseExperience(int amount)
    {
        _experience += amount;

        LevelUpChecker();
    }

    private void LevelUpChecker()
    {
        if (_experience < _experienceCap) return;
        _level++;
        _experience -= _experienceCap;
        _experienceCap += _experienceCapIncrease;
    }

    public void RestoreHealth(float amount)
    {
        _health += amount;
        if (_health >= stats.maxHealth)
            _health = stats.maxHealth;
    }

    public void Damage(float dmg)
    {
        _health -= dmg;
        if (_health <= 0.0f)
            Die();
    }

    public void Die()
    {
        Debug.Log("Die");
    }
}