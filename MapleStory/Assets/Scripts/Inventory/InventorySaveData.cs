using System;
using System.Collections.Generic;

[Serializable]
public class InventorySlotData
{
    public string itemId;
    public int amount;
}

[Serializable]
public class InventorySaveData
{
    public List<InventorySlotData> slots = new List<InventorySlotData>();
}
