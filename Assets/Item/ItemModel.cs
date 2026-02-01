

using System.Collections.Generic;

public class ItemModel
{
    private ItemData itemData;

    public ItemData Data => itemData;


    public ItemModel(ItemData itemData)
    {
        this.itemData = itemData;
    }
}