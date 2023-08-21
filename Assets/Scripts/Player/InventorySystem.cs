using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventorySystem : MonoBehaviour
{
    [SerializeField] private int maxWeapons;
    [SerializeField] private int maxAbilities;
    private List<Weapon> _weapons;
    [SerializeField] private List<Image> _weaponUIImages;
    private List<AbilityItem> _abilities;
    [SerializeField] private List<Image> _abilitiesUIImages;

    public List<Weapon> Weapons => _weapons;

    public void AddWeapon(Weapon weapon)
    {
        _weapons ??= new List<Weapon>(maxWeapons);
        _weapons.Add(weapon);
        _weaponUIImages[_weapons.IndexOf(weapon)].sprite = weapon.UIIcon;
    }

    public void AddAbility(AbilityItem abilityItem)
    {
        _abilities ??= new List<AbilityItem>(maxAbilities);
        _abilities.Add(abilityItem);
        _abilitiesUIImages[_abilities.IndexOf(abilityItem)].sprite = abilityItem.UIIcon;
    }

    public void LevelUpWeapon(Weapon weapon)
    {
        foreach (var wp in _weapons)
        {
            if (!ReferenceEquals(wp, weapon)) continue;
            wp.LevelUp();
        }
    }

    public void LevelUpAbility(AbilityItem abilityItem)
    {
        foreach (var ability in _abilities)
        {
            if (!ReferenceEquals(ability, abilityItem)) continue;
            ability.LevelUp();
        }
    }
}