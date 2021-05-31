using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patience : Skill_Manager
{
    public GameObject FireArrowShotPoint;
    GameObject ShotPointCache;
    float hold;
    void Start()
    {
        this.Skill_Num = 32;
        //this.Sprite_Num =
        ShotPointCache = FireArrowShotPoint;
    }

    
    void Update()
    {
        if (this.Selected)
        {
            if (!ShotPointCache.GetComponent<Fire_Arrow_ShotPoint>().isShoot)
                hold += Time.deltaTime;

            //if (ShotPointCache.GetComponent<Fire_Arrow_ShotPoint>().isShoot)
                
        }
    }
}
