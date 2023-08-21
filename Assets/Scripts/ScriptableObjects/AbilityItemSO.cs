using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "AbilityItem", menuName = "AbilityItem", order = 2)]
public class AbilityItemSO : ScriptableObject
{
    public float multiplier;
    public int maxLevel;
}