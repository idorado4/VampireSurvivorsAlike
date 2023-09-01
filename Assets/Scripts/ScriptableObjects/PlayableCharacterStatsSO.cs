using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Stats/Playable Character", fileName = "PlayableCharacterStats")]
public class PlayableCharacterStatsSO : CharacterStatsSO
{
    [Header("Custom Player Stats")]
    public float recovery;
    public float attackDmg;
    public float collectorRadius;
    public WeaponController initialWeapon;
    [Header("Leveling")]
    [SerializeField] private int level = 1;
    [SerializeField] private int experienceCap = 100;
    [SerializeField] private int experienceCapIncrease = 100;
}