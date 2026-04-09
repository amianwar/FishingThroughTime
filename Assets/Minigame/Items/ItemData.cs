using UnityEngine;

public enum ItemType {Fish, Rod, Junk}

[CreateAssetMenu(fileName = "NewItem", menuName = "Inventory/Item")]
public class ItemData : ScriptableObject
{
    public string itemName;
    [TextArea]
    public string description;
    public Sprite icon;
    public ItemType itemType;
    public int quantity;
    public int maxStackSize = 1;
}