using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventorySystem : MonoBehaviour
{

    [SerializeField] private int maxWeapons;
    [SerializeField] private int maxAbilities;
    private Dictionary<Weapon, int> _weapons;
    private Dictionary<AbilityItem, int> _abilities;

    private void Awake()
    {
        _weapons = new Dictionary<Weapon, int>(maxWeapons);
        _abilities = new Dictionary<AbilityItem, int>(maxAbilities);
    }

    public void AddWeapon(Weapon weapon)
    {
        _weapons.Add(weapon, 1);
    }

    public void AddAbility(AbilityItem abilityItem)
    {
        _abilities.Add(abilityItem, 1);
    }

    public void LevelUpWeapon(Weapon weapon)
    {
        _weapons[weapon]++;
        
    }

    public void LevelUpAbility(AbilityItem abilityItem)
    {
        _abilities[abilityItem]++;

    }
}