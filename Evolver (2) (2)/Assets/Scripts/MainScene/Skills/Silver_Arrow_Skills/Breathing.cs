using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Breathing : Skill_Manager
{
    public GameObject Player;
    GameObject PlayerCache;
    float StandTime;
    float Original_RecoverSpeed;
    bool isOnce;
    void Start()
    {
        this.Skill_Num = 24;
        this.Skill_Name = "ȣ��";
        this.Skill_Desc = "2�� �̻� �������� �ʰ� ������ ���� ��� ���׹̳��� ȸ�� �ӵ��� �����Ѵ�.";
        //this.Sprite_Num =
        PlayerCache = Player;
        Original_RecoverSpeed = Player_Stat.instance.Stamina_recovery_speed;
    }

    
    void Update()
    {
        if (this.Selected)
        {
            if (!PlayerCache.transform.hasChanged)                      //hasChanged ���� false��� �������� ���� ����. �� ���°� 2�ʰ� ���ӵǸ� ȸ���ӵ� ����
            {
                StandTime += Time.deltaTime;
                if(StandTime > 2f && !isOnce)
                {
                    isOnce = true;
                    Player_Stat.instance.Stamina_recovery_speed += 3f;
                }
            }
            else if (PlayerCache.transform.hasChanged)                  //�÷��̾��� �������� �����ȴٸ�
            {
                isOnce = false;
                StandTime = 0f;
                Player_Stat.instance.Stamina_recovery_speed = Original_RecoverSpeed;
                PlayerCache.transform.hasChanged = false;
            }



            if (PlayerCache.layer == LayerMask.NameToLayer("PlayerInShelter"))
            {
                Original_RecoverSpeed = Player_Stat.instance.Stamina_recovery_speed;        // �ɷ�ġ�� ��ȭ�� ���� ���� �ִ� ���Ϳ����� ��� ���� ������Ʈ ���ֵ��� �Ѵ�.
            }
        }
    }
}
