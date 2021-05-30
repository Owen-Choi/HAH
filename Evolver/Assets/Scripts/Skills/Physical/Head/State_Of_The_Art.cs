using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State_Of_The_Art : Physical_Manager
{
    public GameObject Player;
    GameObject PlayerCache;
    bool Available;
    protected Color cr;
    protected Color OriginCol;
    void Start()
    {
        this.Skill_Num = 44;
        //this.Sprite_Num =
        this.Skill_Name = "State of the Art";
        this.Skill_Desc = "";
        Available = true;
        PlayerCache = Player;
        cr.r = 212f;
        cr.g = 77f;
        cr.b = 77f;
        cr.a = 1;
        OriginCol.r = 255f;
        OriginCol.g = 255f;
        OriginCol.b = 255f;
        OriginCol.a = 1;

    }

    
    void Update()
    {
        // # Player_Stat의 AbsolCrit 변수를 활용해보자
        if (this.Selected)
        {
            if (Input.GetKeyDown(KeyCode.L) && Player_Stat.instance.stamina >= 50 && Available){
                Available = false;
                Player_Stat.instance.stamina -= 50;
                Player_Stat.instance.AbsolCrit = true;
                PlayerCache.GetComponent<SpriteRenderer>().color = cr;          //활성화 시 Player 오브젝트의 색을 변경한다.
                StartCoroutine("Duration");
            }

            if (!Available)
                StartCoroutine("CoolTime");
        }
    }
    IEnumerator Duration()
    {
        yield return new WaitForSeconds(5f);
        Player_Stat.instance.AbsolCrit = false;
        PlayerCache.GetComponent<SpriteRenderer>().color = OriginCol;           //지속시간이 끝나면 다시 원상태로 되돌림
    }
    IEnumerator CoolTime()
    {
        yield return new WaitForSeconds(60f);
        Available = true;
    }
}
