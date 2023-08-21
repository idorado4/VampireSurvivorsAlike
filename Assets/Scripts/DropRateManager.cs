using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropRateManager : MonoBehaviour
{
    [Serializable]
    public class Drop
    {
        public GameObject prefab;
        [Range(1.0f, 100.0f)] public float rate;
    }

    [SerializeField] private List<Drop> drops;

    public void OnDie()
    {
        var randomNumber = UnityEngine.Random.Range(0.0f, 100.0f);
        List<Drop> possibleDrops = new List<Drop>();

        foreach (var drop in drops)
        {
            if (randomNumber <= drop.rate)
            {
                possibleDrops.Add(drop);
            }
        }

        if (possibleDrops.Count <= 0) return;
        var dropToSpawn = possibleDrops[UnityEngine.Random.Range(0, possibleDrops.Count)];
        Instantiate(dropToSpawn.prefab, transform.position, Quaternion.identity);
    }
}