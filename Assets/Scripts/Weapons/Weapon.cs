using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public abstract class Weapon : MonoBehaviour
{
    public WeaponDataSO data;
    protected PlayerController Player;
    private int _level;
    private int _maxLevel;
    private float LastTimeUsed { get; set; }

    private bool CanBeUsed { get; set; }
    private void Update()
    {
        if (!CanBeUsed) return;
        if (Time.time > LastTimeUsed + data.cooldown)
            Use();
    }

    public void Lock()
    {
        CanBeUsed = false;
    }
    
    public virtual void Unlock(PlayerController player)
    {
        Player = player;
        LastTimeUsed = Time.time;
        CanBeUsed = true;
    }
    
    
    
    public virtual void Use()
    {
        LastTimeUsed = Time.time;
    }

    
}