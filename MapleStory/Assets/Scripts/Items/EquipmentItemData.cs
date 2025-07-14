using UnityEngine;

[CreateAssetMenu(fileName = "NewEquipment", menuName = "Items/Equipment Item")]
public class EquipmentItemData : ItemData
{
    public int attackPower;
    public int defensePower;
    public EquipmentType equipmentType;

    public override void Use()
    {
        EquipmentManager.Instance.Equip(this);
    }
}

public enum EquipmentType
{
    Weapon,
    Armor,
    Accessory
}
