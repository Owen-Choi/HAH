using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pyro : Skill_Manager
{
    
    // Start is called before the first frame update
    void Start()
    {
        this.Skill_Num = 26;
        this.Sprite_Num = 26;
        this.Skill_Name = "Pyro";
        this.Skill_Desc = "The burning enemy died instantly at a very low probability ";
    }

    // Update is called once per frame
    void Update()
    {
        if(this.Selected_First)
        {
            this.Selected = true;
            Player_Stat.instance.isPyro = true;           //오류의 여지가 있다. 예의주시하기
            return;
        }
    }
}
