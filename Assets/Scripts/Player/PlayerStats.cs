using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour, IDamageable
{
    [SerializeField] private PlayerStatsSO stats;
    [SerializeField] private InventorySystem _inventorySystem;
    [Header("Leveling")] [SerializeField] private int _experience;
    [SerializeField] private int _level = 1;
    [SerializeField] private int _experienceCap = 100;
    [SerializeField] private int _experienceCapIncrease = 100;


    public float Health { get; set; }
    public float Speed { get; set; }
    public float Recovery { get; set; }
    public float ProjectileSpeed { get; set; }
    public float AttackDmg { get; set; }
    public float CollectorRadius { get; set; }


    public delegate void IncreaseCollectorRadius(float amount);

    public IncreaseCollectorRadius OnIncreaseCollectorRadius;
    
    public delegate void UpgradeWeaponHandler();

    public UpgradeWeaponHandler OnLevelUp;

    private void Awake()
    {
        Health = stats.maxHealth;
        Speed = stats.speed;
        Recovery = stats.recovery;
        ProjectileSpeed = stats.projectileSpeed;
        AttackDmg = stats.attackDmg;
        CollectorRadius = stats.collectorRadius;

        SpawnWeapon(stats.initialWeapon);
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
        OnLevelUp?.Invoke();
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

    public void IncreaseColRadius(float amount)
    {
        //TODO incrementar el radio según sea necesario
        CollectorRadius += amount;
        OnIncreaseCollectorRadius?.Invoke(CollectorRadius);
    }

    public void SpawnWeapon(Weapon weapon)
    {
        var playerTransform = transform;
        var spawnedWeapon = Instantiate(weapon, playerTransform.position, Quaternion.identity, playerTransform);
        spawnedWeapon.Unlock(this);
        _inventorySystem.AddWeapon(spawnedWeapon);
    }
    
    public void AddAbility(AbilityItem abilityItem)
    {
        _inventorySystem.AddAbility(abilityItem);
    }
    
}