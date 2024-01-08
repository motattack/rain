using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
public class Item : ScriptableObject
{
    [Header("Базовые")]
    public string Name = " ";
    [TextArea] public string Description = "Описание";
    public Sprite icon = null;

    public bool isHealing;
    public float healingPower;

    public bool isLetter;
    [TextArea] public string textLetter;
}
