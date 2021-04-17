using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item
{
    public enum ItemType {
        Bandage,
        StaminaPotion,
        Medikit,
        MutantSample,
    }

    public ItemType itemtype;
    public int amount;

}
