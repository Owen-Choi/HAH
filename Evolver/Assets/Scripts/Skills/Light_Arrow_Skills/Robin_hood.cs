using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Robin_hood : Skill_Manager
{
    bool Once;  bool Twice; bool Third;
    public GameObject Player;                   //캐싱하여 사용하자
    GameObject PlayerCache;
    public GameObject ShotPoint;
    GameObject SP;
    int Count;
    void Start()
    {
        Once = Twice = Third = false;
        this.Skill_Num = 7;
        this.Sprite_Num = 12;
        this.Skill_Name = "로빈 후드";
        this.Skill_Desc = "질주하는 동안 스테미나 감소와 차징시간 없이 1회 풀차징으로 공격할 수 있다.";
        PlayerCache = Player;                    
        SP = ShotPoint;
        Count = 0;
    }

    void Update()
    {
        if (this.Selected_First && !Once)
            Once = true;

        if (this.Selected_Second && !Twice)
            Twice = true;

        if (this.Selected_Last && !Third)
            Third = true;

        if(Once && !Twice)
        {
            if(PlayerCache.gameObject.layer == LayerMask.NameToLayer("Player_Dash") && Count < 1)
            {
                this.Skill_Desc = "질주하는 동안 스테미나 감소와 차징시간 없이 2회 풀차징으로 공격할 수 있다.";
                if (Input.GetMouseButtonDown(0))
                {
                    SP.GetComponent<ShotPoint>().RobinHood();
                    Count++;
                    StartCoroutine("SetToZero");
                }
            }
        }
        else if(Once && Twice && !Third)
        {
            this.Skill_Desc = "질주하는 동안 스테미나 감소와 차징시간 없이 3회 풀차징으로 공격할 수 있다.";
            if (PlayerCache.gameObject.layer == LayerMask.NameToLayer("Player_Dash") && Count < 2)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    SP.GetComponent<ShotPoint>().RobinHood();
                    Count++;
                    StartCoroutine("SetToZero");
                }
            }
        }
        else if(Once && Twice && Third)
        {
            if (PlayerCache.gameObject.layer == LayerMask.NameToLayer("Player_Dash") && Count < 3)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    SP.GetComponent<ShotPoint>().RobinHood();
                    Count++;
                    StartCoroutine("SetToZero");
                }
            }
        }
    }

    IEnumerator SetToZero()
    {
        yield return new WaitForSeconds(2f);
        Count = 0;
    }
}
