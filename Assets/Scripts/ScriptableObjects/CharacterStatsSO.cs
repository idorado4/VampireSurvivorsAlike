using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStatsSO : ScriptableObject
{
    [Header("Generic Character Stats")]
    public int ID;
    public float maxHealth;
    public float speed;
    public float projectileSpeed;
}
