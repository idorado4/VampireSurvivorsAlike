using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Stats/Enemy", fileName = "EnemyStats")]

public class EnemyStatsSO : CharacterStatsSO
{
    [Header("Custom Enemy Stats")]
    public int damage;
}
