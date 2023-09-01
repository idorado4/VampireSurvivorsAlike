using UnityEngine;

public class WeaponStats
{
    private WeaponStatsSO _stats;

    public string ID => _stats.id;
    public WeaponType Type => _stats.type;
    public ProjectileController Prefab => _stats.prefab;
    public Sprite UIIcon => _stats.uiIcon;
    public int MaxLevel => _stats.maxLevel;

    private float cooldown;

    public float Cooldown
    {
        get => cooldown;
        private set => cooldown = value;
    }

    private int maxProjectiles;

    public int MaxProjectiles
    {
        get => maxProjectiles;
        private set => maxProjectiles = value;
    }

    public WeaponStats(WeaponStatsSO stats)
    {
        _stats = stats;
        Cooldown = _stats.cooldown;
        MaxProjectiles = _stats.maxProjectiles;
    }
    
    
}