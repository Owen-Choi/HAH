using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory
{
    private List<Item> itemList;

    public Inventory()
    {
        itemList = new List<Item>();

        AddItem(new Item { itemtype = Item.ItemType.Bandage, amount = 3 });
        AddItem(new Item { itemtype = Item.ItemType.StaminaPotion, amount = 3 });
        AddItem(new Item { itemtype = Item.ItemType.MutantSample, amount = 5 });
    }
    public void AddItem(Item item)
    {
        itemList.Add(item);
    }

   
}
