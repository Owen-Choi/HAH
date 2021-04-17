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

    public ItemType itemtype;           //enum에 접근할 때 사용하는 변수
    public int amount;
    public int MutantSampleDropPercent = 2;
    public int BandageDropPercent;
    public int StaminaPotionDropPercent;
    public int MedikitDropPercent;
}
