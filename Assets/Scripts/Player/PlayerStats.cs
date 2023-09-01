using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour, IDamageable
{
    [SerializeField] private PlayableCharacterStatsSO stats;
    [SerializeField] private InventorySystem _inventorySystem;

    public int Experience { get; private set; }

    public float Health { get; set; }
    public float Speed { get; set; }
    public float Recovery { get; set; }
    public float ProjectileSpeed { get; set; }
    public float AttackDmg { get; set; }
    public float CollectorRadius { get; set; }


    private void Awake()
    {
        Health = stats.maxHealth;
        Speed = stats.speed;
        Recovery = stats.recovery;
        ProjectileSpeed = stats.projectileSpeed;
        AttackDmg = stats.attackDmg;
        CollectorRadius = stats.collectorRadius;
    }

    public void IncreaseExperience(int amount)
    {
        Experience += amount;

        LevelUpChecker();
    }

    private void LevelUpChecker()
    {
        // if (Experience < _experienceCap) return;
        // _level++;
        // Experience -= _experienceCap;
        // _experienceCap += _experienceCapIncrease;
        // OnLevelUp?.Invoke();
    }

    public void RestoreHealth(float amount)
    {
        Health += amount;
        if (Health >= stats.maxHealth)
            Health = stats.maxHealth;
    }

    public void Damage(float dmg)
    {
        Health -= dmg;
        if (Health <= 0.0f)
            Die();
    }

    public void Die()
    {
        Debug.Log("Die");
    }

}