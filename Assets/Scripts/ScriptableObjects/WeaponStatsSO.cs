using UnityEngine;

[CreateAssetMenu(menuName = "Weapon", fileName = "WeaponStats", order = 1)]
public class WeaponStatsSO : ScriptableObject
{
    [Header("Generic Properties")]
    public string id;
    public WeaponType type;
    public ProjectileController prefab;
    public Sprite uiIcon;
    public int maxLevel;
    public float cooldown;
    public int maxProjectiles;
}