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
        this.Sprite_Num = 4;
        this.Skill_Name = "�ñ��� ����";
        this.Skill_Desc = "L Ű�� ���� ���׹̳��� 50 �Ҹ��ϰ� 5�� ���� ��� ������ ġ��Ÿ�� �����Ų��. ";
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
        // # Player_Stat�� AbsolCrit ������ Ȱ���غ���
        if (this.Selected)
        {
            if (Input.GetKeyDown(KeyCode.L) && Player_Stat.instance.stamina >= 50 && Available){
                Available = false;
                Player_Stat.instance.stamina -= 50;
                Player_Stat.instance.AbsolCrit = true;
                PlayerCache.GetComponent<SpriteRenderer>().color = cr;          //Ȱ��ȭ �� Player ������Ʈ�� ���� �����Ѵ�.
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
        PlayerCache.GetComponent<SpriteRenderer>().color = OriginCol;           //���ӽð��� ������ �ٽ� �����·� �ǵ���
    }
    IEnumerator CoolTime()
    {
        yield return new WaitForSeconds(60f);
        Available = true;
    }
}
