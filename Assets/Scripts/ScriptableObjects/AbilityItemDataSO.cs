using UnityEngine;

[CreateAssetMenu(fileName = "AbilityItem", menuName = "AbilityItem", order = 2)]
public class AbilityItemDataSO : ScriptableObject
{
    public float multiplier;
    public int maxLevel;
    public Sprite uiIcon;
}