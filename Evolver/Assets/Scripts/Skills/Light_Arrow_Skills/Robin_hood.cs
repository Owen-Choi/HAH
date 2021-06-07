using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Robin_hood : Skill_Manager
{
    bool Once;  bool Twice; bool Third;
    public GameObject Player;                   //ĳ���Ͽ� �������
    GameObject PlayerCache;
    public GameObject ShotPoint;
    GameObject SP;
    int Count;
    void Start()
    {
        Once = Twice = Third = false;
        this.Skill_Num = 7;
        this.Sprite_Num = 12;
        this.Skill_Name = "�κ� �ĵ�";
        this.Skill_Desc = "�����ϴ� ���� ���׹̳� ���ҿ� ��¡�ð� ���� 1ȸ Ǯ��¡���� ������ �� �ִ�.";
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
                this.Skill_Desc = "�����ϴ� ���� ���׹̳� ���ҿ� ��¡�ð� ���� 2ȸ Ǯ��¡���� ������ �� �ִ�.";
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
            this.Skill_Desc = "�����ϴ� ���� ���׹̳� ���ҿ� ��¡�ð� ���� 3ȸ Ǯ��¡���� ������ �� �ִ�.";
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
