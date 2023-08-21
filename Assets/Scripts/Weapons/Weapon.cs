using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public abstract class Weapon : MonoBehaviour
{  
    
    public class ProjectileStats
    {
        public float damage;  
        public float speed;
        public float pierce;  
        public float dmgRange;

        public ProjectileStats(float damage, float speed, float pierce, float dmgRange)
        {
            this.damage = damage;
            this.speed = speed;
            this.pierce = pierce;
            this.dmgRange = dmgRange;
        }
    }
    
    [SerializeField] protected WeaponDataSO data;
    protected PlayerStats _playerStats;
    private int _maxLevel;
    
    protected int Level { get; set; } = 1;
    protected float Damage { get; set; }
    protected float DamageRange { get; set; }
    protected int Pierce { get; set; }
    private float LastTimeUsed { get; set; }

    private bool CanBeUsed { get; set; }

    protected ProjectileStats _projectileStats;
    
    protected virtual void Update()
    {
        if (!CanBeUsed) return;
        if (Time.time > LastTimeUsed + data.cooldown)
            Use();
    }

    public void Lock()
    {
        CanBeUsed = false;
    }

    public virtual void Unlock(PlayerStats playerStats)
    {
        _playerStats = playerStats;
        LastTimeUsed = Time.time;
        CanBeUsed = true;
        _maxLevel = data.maxLevel;
        _projectileStats = new ProjectileStats(data.damage, data.speed, data.pierce, data.dmgRange);
    }


    public virtual void Use()
    {
        LastTimeUsed = Time.time;
    }

    public virtual void LevelUp()
    {
        Level++;
    }
}