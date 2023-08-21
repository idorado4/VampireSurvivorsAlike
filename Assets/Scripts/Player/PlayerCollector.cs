using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollector : MonoBehaviour
{
    [SerializeField] private PlayerStats playerStats;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.TryGetComponent(out ICollectible collectible)) return;
        collectible.Collect(playerStats);
    }
}