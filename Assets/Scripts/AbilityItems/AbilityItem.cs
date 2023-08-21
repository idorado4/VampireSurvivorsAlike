using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityItem : MonoBehaviour
{
    protected PlayerStats _playerStats;
    [SerializeField] protected AbilityItemSO abilityData;


    private void Start()
    {
        ApplyEffect();
    }

    protected virtual void ApplyEffect()
    {
    }
}