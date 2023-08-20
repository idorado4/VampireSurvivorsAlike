using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Weapon", fileName = "WeaponData")]
public class WeaponDataSO : ScriptableObject
{
    [Header("Generic Properties")]
    public int id;
    public WeaponType type;
    public string name;
    public Projectile prefab;
    public int maxLevel;
    public float cooldown;
    public int maxProjectiles;
    
    [Header("Behaviour Properties")]
    public int damage;
    public float dmgRange;
    public float speed; //Movement or rotation
    public float pierce; //How many enemies can the weapon go through
}