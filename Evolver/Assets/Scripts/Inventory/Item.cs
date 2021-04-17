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

    public ItemType itemtype;           //enum�� ������ �� ����ϴ� ����
    public int amount;
    public int MutantSampleDropPercent = 2;
    public int BandageDropPercent;
    public int StaminaPotionDropPercent;
    public int MedikitDropPercent;
}
