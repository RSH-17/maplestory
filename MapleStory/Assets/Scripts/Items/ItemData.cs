using UnityEngine;

[CreateAssetMenu(fileName = "NewItem", menuName = "Items/ItemData")]
public class ItemData : ScriptableObject
{
    [Header("기본 정보")]
    public string itemName;
    [TextArea]
    public string description;
    public string id; // 고유 아이디 (예: "hp_potion_small")

    [Header("아이콘 및 타입")]
    public Sprite icon;
    public ItemType itemType;

    [Header("수량 관련")]
    public bool stackable = true;
    public int maxStack = 99;
    public int amount = 1;

    [Header("사용 이펙트 (옵션)")]
    public GameObject useEffectPrefab;

    public virtual void Use()
    {
        Debug.Log($"[ItemData] {itemName} 을(를) 사용했습니다.");
    }
    
}

public enum ItemType
{
    Consumable,
    Equipment,
    Quest,
    Misc
}
