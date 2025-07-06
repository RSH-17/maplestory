using UnityEngine;

public enum PotionType { HP, MP }

[CreateAssetMenu(fileName = "NewPotion", menuName = "Items/Potion")]
public class PotionData : ScriptableObject
{
    public string potionName;
    public PotionType potionType;
    public float healAmount;
    [TextArea]
    public string description;
}
