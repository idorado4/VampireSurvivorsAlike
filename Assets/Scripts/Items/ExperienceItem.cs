using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExperienceItem : MonoBehaviour, ICollectible
{
    [SerializeField] private int experienceGranted;

    public void Collect(PlayerStats playerStats)
    {
        //TODO Hacer que se mueva hasta el player con una corutina en vez de desaparecer directamente 
        playerStats.IncreaseExperience(experienceGranted);
        Destroy(gameObject);
    }
}