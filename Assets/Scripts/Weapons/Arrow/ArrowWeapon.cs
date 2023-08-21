using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowWeapon : Weapon
{
    [Serializable]
    public class Upgrade
    {
        public float damage;
        public float speed;
        public float pierce;
    }

    //TODO Hacer una pool de proyectiles
    private Vector2 _lastInputDirection = Vector2.right;

    [SerializeField] private List<Upgrade> upgrades;
    private Upgrade _currentLevelUpgrade;

    protected override void Update()
    {
        base.Update();
        var inputMovement = InputManager.Instance.GetMovement();
        if (inputMovement != Vector2.zero)
            _lastInputDirection = inputMovement;
    }

    public override void Unlock(PlayerStats playerStats)
    {
        base.Unlock(playerStats);
        _currentLevelUpgrade = upgrades[Level];
    }

    public override void Use()
    {
        base.Use();
        var angle = Mathf.Atan2(_lastInputDirection.y, _lastInputDirection.x);
        angle *= Mathf.Rad2Deg;
        var newRotation = Quaternion.AngleAxis(angle, Vector3.forward);
        var clone = Instantiate(data.prefab,
            _playerStats.transform.position,
            newRotation);
        clone.Init(_projectileStats, _playerStats);
        var arrowProjectile = (ArrowProjectile) clone;
        arrowProjectile.SetDirection(_lastInputDirection);
    }

    public override void LevelUp()
    {
        base.LevelUp();
        _projectileStats.damage *= 1 + _currentLevelUpgrade.damage / 100;
        _projectileStats.speed *= 1 + _currentLevelUpgrade.speed / 100;
        _projectileStats.pierce += _currentLevelUpgrade.pierce;
        _currentLevelUpgrade = upgrades[Level];
    }
}