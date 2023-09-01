using UnityEngine;

public abstract class WeaponController : MonoBehaviour
{
    [SerializeField] private WeaponStatsSO _statsSO;
    private IPlayableCharacter _character;
    protected WeaponStats _stats;
    protected ProjectileStats _projectileStats;

    private float currentTime;
    public void Config(IPlayableCharacter character)
    {
        _character = character;
        _stats = new WeaponStats(_statsSO);
        _projectileStats = _stats.Prefab.Stats;
    }

    public void TryShoot()
    {
        currentTime += Time.deltaTime;
        if (currentTime < _stats.Cooldown) return;
        Shoot();
        currentTime = 0.0f;
    }

    protected abstract void Shoot();
}