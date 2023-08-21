using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Stats/Player", fileName = "PlayerStats")]

public class PlayerStatsSO : CharacterStatsSO
{
    [Header("Custom Player Stats")]
    public float might;
}
