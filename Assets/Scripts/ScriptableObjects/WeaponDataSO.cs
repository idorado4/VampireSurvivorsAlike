using UnityEngine;

[CreateAssetMenu(menuName = "Weapon", fileName = "WeaponData", order = 1)]
public class WeaponDataSO : ScriptableObject
{
    [Header("Generic Properties")]
    public int id;
    public WeaponType type;
    public string weaponName;
    public Projectile prefab;
    public int maxLevel;
    public float cooldown;
    public int maxProjectiles;
    
    [Header("Behaviour Properties")]
    public float damage;
    public float dmgRange;
    public float speed; //Movement or rotation
    public int pierce; //How many enemies can the weapon go through
}