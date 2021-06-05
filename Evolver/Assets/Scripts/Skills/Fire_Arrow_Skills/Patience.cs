using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patience : Skill_Manager
{
    public GameObject FireArrowShotPoint;
    GameObject ShotPointCache;
    float hold;
    float Original_Recovery;
    bool isOnce;
    public GameObject Player;
    GameObject PlayerCache;
    void Start()
    {
        this.Skill_Num = 32;
        this.Skill_Name = "�γ���";
        //this.Sprite_Num =
        this.Skill_Desc = "4�ʵ��� �������� ���� ��� ���׹̳� ȸ���ӵ��� �����Ѵ�.";
        ShotPointCache = FireArrowShotPoint;
        PlayerCache = Player;
        Original_Recovery = Player_Stat.instance.Stamina_recovery_speed;            //���ʿ� �ѹ� ���� ���� �־��ش�.
    }

    
    void Update()
    {
        if (this.Selected)
        {
            if (!ShotPointCache.GetComponent<Fire_Arrow_ShotPoint>().isShoot)
            {
                hold += Time.deltaTime;
            }
            if (ShotPointCache.GetComponent<Fire_Arrow_ShotPoint>().isShoot)
            {
                hold = 0f;
                Player_Stat.instance.Stamina_recovery_speed = Original_Recovery;
                isOnce = false;
                ShotPointCache.GetComponent<Fire_Arrow_ShotPoint>().isShoot = false;
            }

            if(hold > 4f && !isOnce)
            {
                isOnce = true;
                Player_Stat.instance.Stamina_recovery_speed += 3f;
            }

            if(PlayerCache.layer == LayerMask.NameToLayer("PlayerInShelter"))
            {
                Original_Recovery = Player_Stat.instance.Stamina_recovery_speed;            //��ġ�� ������ ���� ���� �ִ� ���Ϳ����� ���������� ���� ������Ʈ
            }    
        }
    }
}
