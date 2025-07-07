using UnityEngine;

[System.Serializable]
public class ItemData
{
    public string itemName;
    public Sprite icon;
    public string description;
    public ItemType itemType;
    public int amount = 1;

    // 포션일 경우
    public int recoverHP;
    public int recoverMP;

    // 장비일 경우
    public int attackPower;
    public int defensePower;
    
    public EquipmentType equipmentType;
    public enum ItemType
    {
        Consumable,
        Equipment,
        Quest
    }
    public enum EquipmentType
    {
        Weapon,
        Armor,
        Accessory
    }
    // 수량 증가 메서드
    public void AddAmount(int value)
    {
        amount += value;
    }

    public void SetAmount(int value)
    {
        amount = value;
    }
}

