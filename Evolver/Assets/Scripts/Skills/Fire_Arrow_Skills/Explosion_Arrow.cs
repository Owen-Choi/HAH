using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion_Arrow : Skill_Manager
{
    public GameObject Explode;
    bool ChangeOnce;    bool ChangeTwice;   bool ChangeLast;
    public GameObject Fire_Arrow_ShotPoint;
    // Start is called before the first frame update
    void Start()
    {
        this.Skill_Num = 27;
        ChangeOnce = false;
        ChangeTwice = false;
        ChangeLast = false;
        this.Sprite_Num = 27;
    }

    // Update is called once per frame
    void Update()
    {
        if (this.Selected_First && !ChangeOnce)
        {
            Fire_Arrow_ShotPoint.GetComponent<Fire_Arrow_ShotPoint>().is_Explode = true;
            Player_Stat.instance.criticalPercent -= 10;
            ChangeOnce = true;
            this.Sprite_Num = 28;
        }

        if(this.Selected_Second && !ChangeTwice)
        {
            ChangeTwice = true;
            Player_Stat.instance.criticalPercent += 5;
            Player_Stat.instance.Explode_Multiple_Damage += 0.5f;
            this.Sprite_Num = 29;
        }

        if(this.Selected_Last && !ChangeLast)
        {
            this.Selected = true;
            ChangeLast = true;
            Player_Stat.instance.Explode_Multiple_Damage += 0.5f;
            return;
        }
    }
}
