using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "InventoryManager", menuName = "Inventory Manager")]
public class InventoryManager : ScriptableObject
{

    [Header("Score")]
    [SerializeField]
    private int Score = 0;

    [Header("Items")]
    public List<Item> items = new List<Item>();


    public void Initialize()
    {
        Score = 0;
        items.Clear();
    }
}

[Serializable]
public class Item
{
    public string name;
    public string description;
}

