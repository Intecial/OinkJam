using UnityEngine;


[CreateAssetMenu(fileName = "NewItemConfig", menuName = "Item Config")]
public class ItemConfig : ScriptableObject
{
    public string itemName;
    public ItemTypes itemType;
    public Sprite sprite;
}