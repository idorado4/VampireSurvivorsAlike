using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthItem : MonoBehaviour, ICollectible
{
    [SerializeField] private float pointsToRestore;
    public void Collect(PlayerStats playerStats)
    {
        playerStats.RestoreHealth(pointsToRestore);
        Destroy(gameObject);
    }
}