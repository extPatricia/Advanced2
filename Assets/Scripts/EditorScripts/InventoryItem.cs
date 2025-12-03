using UnityEngine;
using System;

[CreateAssetMenu(fileName = "New Inventory Item", menuName = "Inventory/Create Item")]
public class InventoryItem : ScriptableObject
{
    public string itemName;
    public Sprite itemIcon;
    public int itemQuantity;
    public bool isStackable;
}
