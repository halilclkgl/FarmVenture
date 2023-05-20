using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ShopDatabase
{
    public List<ShopItem> items;

    public ShopItem GetItemByName(string itemName)
    {
        return items.Find(item => item.itemName == itemName);
    }

    public void UpdateStock(string itemName, int newStock)
    {
        ShopItem item = GetItemByName(itemName);
        if (item != null)
        {
            item.stock = newStock;
        }
    }
}
