
using UnityEngine;

[CreateAssetMenu(fileName = "NewItem", menuName = "Item Data")]
public class ItemData : ScriptableObject
{
    public string itemName;
    public ItemTypes itemType;
    public Sprite sprite;
    
}