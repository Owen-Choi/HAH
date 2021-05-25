using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gambler : Physical_Manager
{
    private bool Selected_Once;


    private void Awake()
    {
        this.Skill_Num = 2;
        this.Sprite_Num = 18;
        this.Skill_Name = "Gambler";
        this.Skill_Desc = "Increases dodge percent as 30%, but max health decreases 20% ";
    }
    private void Update()
    {
        if(this.Selected && !this.Selected_Once)
        {
            // # ȸ��Ȯ�� 30�� ����, �ִ�ü�� 20�� ����
            this.Selected = false;
            this.Selected_Once = true;
            Player_Stat.instance.missPercent += 30;
            Player_Stat.instance.DefaultHealthMax -= Player_Stat.instance.DefaultHealthMax * 0.2f;
        }
    }
}
