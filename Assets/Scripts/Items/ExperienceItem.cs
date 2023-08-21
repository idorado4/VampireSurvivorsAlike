using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExperienceItem : MonoBehaviour, ICollectible
{
    [SerializeField] private int experienceGranted;

    public void Collect(PlayerStats playerStats)
    {
        playerStats.IncreaseExperience(experienceGranted);
        Destroy(gameObject);
    }
}