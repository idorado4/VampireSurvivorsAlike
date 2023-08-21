using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Stats/Enemy", fileName = "EnemyStats")]

public class EnemyStats : CharacterStatsSO
{
    [Header("Custom Enemy Stats")]
    public int damage;
}
