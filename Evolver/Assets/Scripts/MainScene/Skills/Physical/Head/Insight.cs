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
        this.Skill_Name = "������";
        //this.Sprite_Num =
        this.Skill_Desc = "�÷��̾��� �þ� �ݰ��� �ణ �о�����.";
        PlayerCache = Player;
    }

   // # Player�� Point Light�� 4��° Child(���ڷδ� 3)
    void Update()
    {
        if(this.Selected)
        {
            this.Selected = false;
            // # Light2D�� ���� ���̺귯���� �߰��ؾ� ������ �� �ִ�.
            if(PlayerCache.transform.GetChild(3).GetComponent<Light2D>().pointLightOuterRadius < 10)
                PlayerCache.transform.GetChild(3).GetComponent<Light2D>().pointLightOuterRadius++;
        }
    }
}
