using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory
{
    //������ ���
    public int MutantSample;    public int MutantSampleDropPercent = 100;
    public int Bandage;         public int BandageDropPercent = 4;
    public int Medikit;         public int MedikitDropPercent = 1;
    public int StaminaPotion;   public int StaminaPotionDropPercent = 3;

    //�κ��丮 ���� ���� �� �⺻ ���� ������ ���
    public Inventory()     
    {
        MutantSample = 5;
        Bandage = 3;
        Medikit = 1;
        StaminaPotion = 3;
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
            default:
                return -1;
                //����Ʈ�� ���� ����ó���� ���� �����غ����� ����
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
            default:
                return -1;
                //����Ʈ�� ���� ����ó���� ���� �����غ����� ����
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
        }
    }
}
