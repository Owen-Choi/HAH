using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Immediate_Shot : Skill_Manager
{
    public GameObject Silver_Arrow_Weapon;
    public GameObject Silver_Arrow_ShotPoint;
    bool ChangeOnce;    bool ChangeTwice;   protected Color Redcolor;   protected Color OriginColor;    bool FreeStamina;
    bool isOnce;
    // Start is called before the first frame update
    void Start()
    {
        this.Skill_Num = 19;
        ChangeOnce = false;
        ChangeTwice = false;
        Redcolor.r = 255f; Redcolor.g = 0f;   Redcolor.b = 0f;   Redcolor.a = 255f;
        OriginColor.r = 255f;   OriginColor.g = 255f;   OriginColor.b = 255f;   OriginColor.a = 255f;
        this.Sprite_Num = 7;
        this.Skill_Name = "��߻��";
        this.Skill_Desc = "�ѹ��� ������� ġ��Ÿ�� 2�� �̻� �߻��� �� 40�� ���׹̳��� �Ҹ��Ͽ� ��¡ �ð� ���� 1���� �߰� ����� �־�����.";
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Selected_First && !ChangeOnce)
        {
            ChangeOnce = true;
            this.Sprite_Num = 8;
            Silver_Arrow_ShotPoint.GetComponent<Silver_Arrow_ShotPoint>().isImmed = true;
            Silver_Arrow_ShotPoint.GetComponent<Silver_Arrow_ShotPoint>().ISCMax = 2;
            this.Skill_Desc = "�ѹ��� ������� ġ��Ÿ�� 1�� �̻� �߻��� �� 40�� ���׹̳��� �Ҹ��Ͽ� ��¡ �ð� ���� 1���� �߰� ����� �־�����.";
        }

        if(Selected_Second && !ChangeTwice)
        {
            ChangeTwice = true;
            this.Sprite_Num = 9;
            Silver_Arrow_ShotPoint.GetComponent<Silver_Arrow_ShotPoint>().ISCMax = 1;
            this.Skill_Desc = "�ѹ��� ������� ġ��Ÿ�� 1�� �̻� �߻��� �� ���׹̳� �Ҹ�� ��¡ �ð� ���� 1���� �߰� ����� �־�����, ġ��Ÿ Ȯ���� ���������� 20% �����Ѵ�.";
        }

        if(Selected_Last && !isOnce)
        {
            this.Selected = true;
            Player_Stat.instance.criticalPercent += 20; 
            this.FreeStamina = true;
            isOnce = true;
        }

        if(Silver_Arrow_ShotPoint.GetComponent<Silver_Arrow_ShotPoint>().ISCAble)
        {
            Silver_Arrow_Weapon.GetComponent<Silver_Arrow_Weapon>().sp.color = Redcolor;
            Silver_Arrow_ShotPoint.GetComponent<Silver_Arrow_ShotPoint>().Immediate_Shot_Count = 0;
            if (Input.GetMouseButtonDown(1) && !Input.GetMouseButtonDown(0))
            {
                if(FreeStamina) 
                {
                    //CameraShake.instance.cameraShake();       ī�޶� ��鸮�鼭 ���콺 ��ǥ�� ������ ��ģ��. ȭ���� �̻��� �������� Ƣ�����
                    Silver_Arrow_ShotPoint.GetComponent<Silver_Arrow_ShotPoint>().Shoot(Silver_Arrow_ShotPoint.GetComponent<Silver_Arrow_ShotPoint>().TempDMG);
                    Silver_Arrow_ShotPoint.GetComponent<Silver_Arrow_ShotPoint>().ISCAble = false;
                    Silver_Arrow_Weapon.GetComponent<Silver_Arrow_Weapon>().sp.color = OriginColor;
                }
                else
                {
                    if(Player_Stat.instance.stamina > 40f)
                    {
                        //CameraShake.instance.cameraShake();
                        Player_Stat.instance.stamina -= 40f;
                        Silver_Arrow_ShotPoint.GetComponent<Silver_Arrow_ShotPoint>().Shoot(Silver_Arrow_ShotPoint.GetComponent<Silver_Arrow_ShotPoint>().TempDMG);
                        Silver_Arrow_ShotPoint.GetComponent<Silver_Arrow_ShotPoint>().ISCAble = false;
                        Silver_Arrow_Weapon.GetComponent<Silver_Arrow_Weapon>().sp.color = OriginColor;
                    }
                    else { }        //ignore shot
                }
                
            }

        }

    }
}