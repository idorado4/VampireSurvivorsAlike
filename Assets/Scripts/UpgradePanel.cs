using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UpgradePanel : MonoBehaviour
{
    [SerializeField] private TMP_Text itemName;
    [SerializeField] private TMP_Text upgradeDescription;
    [SerializeField] private Image itemIcon;
    [SerializeField] private Button button;

    public Button UpgradeButton => button;

    public void Config(string name, Sprite uiIcon)
    {
        itemName.text = name;
        itemIcon.sprite = uiIcon;
        gameObject.SetActive(true);
    }

}