using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindStep : Skill_Manager
{
    public bool TimeDone = false;
    bool ForOne = false;
    public float time = 0f;
    public GameObject ShotPoint;
    public GameObject BuffCarrier;
    GameObject SP;
    GameObject BCcache;
    bool isShoot;
    
    void Start()
    {
        this.Skill_Num = 6;
        this.Sprite_Num = 2;
        this.Skill_Name = "�ٶ�����";
        this.Skill_Desc = "ȸ������ ���������� �����ϰ� ���� ������ �� ���� �Ͻ������� �̵��ӵ��� �����Ѵ�.";
        BCcache = BuffCarrier;
        SP = ShotPoint;
    }


    void Update()
    {
        if (this.Selected_First)
        {
            if (!ForOne)
            {
                Player_Stat.instance.missPercent += 5;
                ForOne = true;
            }
            this.Selected = true;
            if (SP.GetComponent<ShotPoint>().isShoot && !TimeDone)           //��ȿ������ �ڵ����� �������� �������� �ʴ´�....
                ws();
        }
    }

    void ws()
    {
        TimeDone = true;
        //Player_Stat.instance.moveSpeed += 2;
        BCcache.GetComponent<Buff_Carrier>().buff_MS += 2;
        StartCoroutine("ThreeSecDelay");

    }

    IEnumerator ThreeSecDelay()
    {
        yield return new WaitForSeconds(3f);
        //Player_Stat.instance.moveSpeed -= 2;
        BCcache.GetComponent<Buff_Carrier>().buff_MS -= 2;
        TimeDone = false;
    }

}