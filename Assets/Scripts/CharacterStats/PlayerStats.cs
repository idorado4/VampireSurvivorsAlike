using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Stats/Player", fileName = "PlayerStats")]

public class PlayerStats : CharacterStatsSO
{
    public List<WeaponSO> weapons;
}
