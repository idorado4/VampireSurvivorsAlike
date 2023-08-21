using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BootsItem : AbilityItem
{
    protected override void ApplyEffect()
    {
        _playerStats.Speed *= 1 + abilityData.multiplier / 100;
    }
}
