using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory
{
    //아이템 목록
    public int MutantSample;    public int MutantSampleDropPercent = 100;
    public int Bandage;         public int BandageDropPercent = 4;
    public int Medikit;         public int MedikitDropPercent = 1;
    public int StaminaPotion;   public int StaminaPotionDropPercent = 3;
    public int Food;            public int FoodDropPercent = 20;                         //특정 오브젝트 조사하면 나오게끔.
    public int Water;           public int WaterDropPercent = 20;

    //인벤토리 최초 생성 시 기본 지급 아이템 목록
    public Inventory()     
    {
        MutantSample = 100;
        Bandage = 3;
        Medikit = 1;
        StaminaPotion = 3;
        Food = 5;
        Water = 7;
    }
   
    public int getItemCount(string name)
    {
        switch (name)
        {
            case "MutantSample":
                return MutantSample;
            case "Bandage":
                return Bandage;
            case "Medikit":
                return Medikit;
            case "StaminaPotion":
                return StaminaPotion;
            case "Food":
                return Food;
            case "Water":
                return Water;
            default:
                return -1;
                //디폴트에 대한 오류처리는 차차 생각해보도록 하자
        }
    }

    public int getDropPercent(string name)
    {
        switch (name)
        {
            case "MutantSample":
                return MutantSampleDropPercent;
            case "Bandage":
                return BandageDropPercent;
            case "Medikit":
                return MedikitDropPercent;
            case "StaminaPotion":
                return StaminaPotionDropPercent;
            case "Food":
                return FoodDropPercent;
            case "Water":
                return WaterDropPercent;
            default:
                return -1;
                //디폴트에 대한 오류처리는 차차 생각해보도록 하자
        }
    }
    public void AddItem(string name, int count)
    {
        switch (name) {
            case "MutantSample":
                this.MutantSample += count;
                break;
            case "Bandage":
                this.Bandage += count;
                break;
            case "Medikit":
                this.Medikit += count;
                break;
            case "StaminaPotion":
                this.StaminaPotion += count;
                break;
            case "Food":
                this.Food += count;
                break;
            case "Water":
                this.Water += count;
                break;
        }
    }

    public void SetDropPercent(string name, int percent)
    {
        switch (name)
        {
            case "MutantSample":
                this.MutantSampleDropPercent = percent;
                break;
            case "Bandage":
                this.BandageDropPercent = percent;
                break;
            case "Medikit":
                this.MedikitDropPercent = percent;
                break;
            case "StaminaPotion":
                this.StaminaPotionDropPercent = percent;
                break;
            case "Food":
                this.FoodDropPercent = percent;
                break;
            case "Water":
                this.WaterDropPercent = percent;
                break;
        }
    }

    public void UseItem(string name, int count)
    {
        switch (name)
        {
            case "MutantSample":
                this.MutantSample -= count;
                break;
            case "Bandage":
                this.Bandage -= count;
                break;
            case "Medikit":
                this.Medikit -= count;
                break;
            case "StaminaPotion":
                this.StaminaPotion -= count;
                break;
            case "Food":
                this.Food -= count;
                break;
            case "Water":
                this.Water -= count;
                break;
        }
    }
}
