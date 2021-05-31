using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;
public class Insight : Physical_Manager
{
    public GameObject Player;
    GameObject PlayerCache;
    bool isOnce;
    void Start()
    {
        this.Skill_Num = 45;
        //this.Sprite_Num =
        PlayerCache = Player;
    }

   // # Player의 Point Light는 4번째 Child(숫자로는 3)
    void Update()
    {
        if(this.Selected)
        {
            this.Selected = false;
            // # Light2D는 관련 라이브러리를 추가해야 참조할 수 있다.
            if(PlayerCache.transform.GetChild(3).GetComponent<Light2D>().pointLightOuterRadius < 10)
                PlayerCache.transform.GetChild(3).GetComponent<Light2D>().pointLightOuterRadius++;
        }
    }
}
