using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadioActiveDMG : Physical_Manager
{
    float radioActive;  float Damage;
    float originalDMG;
    void Awake()
    {
        radioActive = Player_Stat.instance.RadioActive;
        originalDMG = Player_Stat.instance.damage;          //기존의 데미지 값을 저장
    }
    void Update()
    {
        if (this.Selected)
        {
            Damage = Player_Stat.instance.damage + radioActive * 0.5f;
            Player_Stat.instance.damage = Damage;
            
        }
    }
}
