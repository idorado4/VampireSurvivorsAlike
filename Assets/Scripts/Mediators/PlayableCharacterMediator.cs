using System;
using System.Collections.Generic;
using UnityEngine;

public class PlayableCharacterMediator : MonoBehaviour, IPlayableCharacter
{
    [SerializeField] private CharacterMovementController _movementController;
    [SerializeField] private List<WeaponController> _weaponControllers;

    private WeaponStats _weaponStats;

    private IInputSystem _input;

    public void Config(IInputSystem input)
    {
        _input = input;
        _movementController.Config(this);
        foreach (var weapon in _weaponControllers)
        {
            weapon.Config(this);
        }
    }

    private void FixedUpdate()
    {
        var direction = _input.GetDirection();
        _movementController.Move(direction);
    }

    public void Update()
    {
        foreach (var weapon in _weaponControllers)
        {
            weapon.TryShoot();
        }
    }
}