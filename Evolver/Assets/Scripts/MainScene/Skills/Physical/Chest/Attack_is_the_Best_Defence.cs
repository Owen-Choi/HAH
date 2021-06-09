using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack_is_the_Best_Defence : Physical_Manager
{

    private void Awake()
    {
        this.Skill_Num = 28;
        this.Sprite_Num = 5;
        this.Skill_Name = "최선의 방어는 공격";
        this.Skill_Desc = "방어력을 깎아 공격력을 증가시킨다. (방어력 5 감소, 공격력 7 증가)";
    }
    private void Update()
    {
        if (this.Selected)
        {
            this.Selected = false;
            Player_Stat.instance.damage += 7f;
            Player_Stat.instance.armor -= 5f;
            // 수치 조정해야할 수도 있다.
        }
    }
}
