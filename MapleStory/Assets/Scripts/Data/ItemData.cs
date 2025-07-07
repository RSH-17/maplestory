using UnityEngine;

[System.Serializable]
public class ItemData
{
    public string itemName;
    public Sprite icon;
    public string description;
    public ItemType itemType;
    public int amount; // 예: 수량

    public enum ItemType
    {
        Consumable,
        Equipment,
        Quest
    }
}
