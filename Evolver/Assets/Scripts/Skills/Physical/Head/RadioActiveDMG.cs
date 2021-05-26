using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadioActiveDMG : Physical_Manager
{
    public GameObject Player;   bool OnlyOnce;
    float radioActive;  float Damage;
    float originalDMG;
    void Awake()
    {
        this.Skill_Num = 39;
        //this.Sprite_Num = 
        originalDMG = Player_Stat.instance.damage;          //기존의 데미지 값을 저장
        this.Skill_Name = "A crisis as an opportunity";
        this.Skill_Desc = "your damage value will be increased as radio active stack";
    }
    void Update()
    {
        if(Player.gameObject.layer == LayerMask.NameToLayer("PlayerInShelter"))
        {
            OnlyOnce = true;
            if (originalDMG < Player_Stat.instance.damage)           
                originalDMG = Player_Stat.instance.damage;
        }

        if(Player.gameObject.layer == LayerMask.NameToLayer("Player") && OnlyOnce)
        {
            OnlyOnce = false;
            radioActive = Player_Stat.instance.RadioActive;             //최초로 맵에 들어갔을 때
        }

        if (this.Selected)
        {
            if(radioActive != Player_Stat.instance.RadioActive)
            {
                Player_Stat.instance.damage = originalDMG + radioActive * 0.5f;     //일단 두고 봐야겠다.
                radioActive = Player_Stat.instance.RadioActive;
            }   
        }

        if (Player.gameObject.layer == LayerMask.NameToLayer("PlayerInShelter") && originalDMG != Player_Stat.instance.damage)
        {
            originalDMG = Player_Stat.instance.damage;
        }

    }
}
