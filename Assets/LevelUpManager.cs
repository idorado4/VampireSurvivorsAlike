using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class LevelUpManager : MonoBehaviour
{
    [SerializeField] private GameObject levelUpCanvas;
    [SerializeField] private InventorySystem _inventorySystem;
    [SerializeField] private PlayerStats _playerStats;

    private void Awake()
    {
        _playerStats.OnLevelUp += LevelUp;
    }

    private void LevelUp()
    {
        Debug.Log("level up manager");
        for (var i = 0; i < 3; i++)
        {
            if (i >= _inventorySystem.Weapons.Count) break;
            var upgradePanel = levelUpCanvas.transform.GetChild(i).GetComponent<UpgradePanel>();
            var weapon = _inventorySystem.Weapons[Random.Range(0, _inventorySystem.Weapons.Count)];
            upgradePanel.Config(weapon.Name, weapon.UIIcon);
            upgradePanel.UpgradeButton.onClick.AddListener(() =>
            {
                weapon.LevelUp();
                levelUpCanvas.SetActive(false);
            });
        }

        levelUpCanvas.SetActive(true);
    }
}