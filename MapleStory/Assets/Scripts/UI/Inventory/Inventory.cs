using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<ItemData> items = new List<ItemData>();
    public int maxSlots = 40;

    public bool AddItem(ItemData item)
    {
        if (items.Count >= maxSlots) return false;
        items.Add(item);
        return true;
    }

    public void RemoveItem(ItemData item)
    {
        items.Remove(item);
    }
}
