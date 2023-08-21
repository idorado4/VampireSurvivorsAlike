using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSystem : MonoBehaviour
{

    [SerializeField] private PlayerMovement _player;
    [SerializeField] private SlimeEnemy slime;
    
    private void Start()
    {
        var clone = Instantiate(slime);
        clone.Init(_player.transform);
    }
}
