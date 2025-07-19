using UnityEngine;

[CreateAssetMenu(fileName = "NewConsumable", menuName = "Items/Consumable Item")]
public class ConsumableItemData : ItemData
{
    public int recoverHP;
    public int recoverMP;

    public override void Use()
    {
        PlayerStats player = Object.FindFirstObjectByType<PlayerStats>();
        if (player != null)
        {
            player.UsePotion(recoverHP, recoverMP);
        }
    }
}
