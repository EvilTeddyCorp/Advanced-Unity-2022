using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;

[CreateAssetMenu(fileName = "NewItemData", menuName = "AUD/Create New Item Data", order = 0)]

public class ItemData : ScriptableObject
{



    public string ItemName;
    [ShowAssetPreview(width: 30, height: 30)]
    public Sprite sprite;
    public int itemprice;
    public ItemType itemType;
    [MinMaxSlider(0, 1)]
    public float dropChance;
    

}

public enum rarity
{
    Common,
    Uncommon,
    Rare,
    Legendary
}

public enum ItemType
{
    Junk,
    Armor,
    Weapon,
    Consumable
}
