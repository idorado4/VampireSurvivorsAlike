using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbilityItem : MonoBehaviour
{
    protected PlayerStats _playerStats;
    [SerializeField] protected AbilityItemDataSO abilityData;
    public int Level { get; set; }
    public Sprite UIIcon { get; set; }
    
    private void Start()
    {
        ApplyEffect();
        UIIcon = abilityData.uiIcon;
    }

    protected virtual void ApplyEffect()
    {
    }

    public abstract void LevelUp();
}