using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Immediate_Shot : Skill_Manager
{
    public GameObject Silver_Arrow_Weapon;
    public GameObject Silver_Arrow_ShotPoint;
    bool ChangeOnce;    bool ChangeTwice;   protected Color Redcolor;   protected Color OriginColor;    bool FreeStamina;
    // Start is called before the first frame update
    void Start()
    {
        this.Skill_Num = 19;
        ChangeOnce = false;
        ChangeTwice = false;
        Redcolor.r = 255f; Redcolor.g = 0f;   Redcolor.b = 0f;   Redcolor.a = 255f;
        OriginColor.r = 255f;   OriginColor.g = 255f;   OriginColor.b = 255f;   OriginColor.a = 255f;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Selected_First && !ChangeOnce)
        {
            ChangeOnce = true;
            Silver_Arrow_ShotPoint.GetComponent<Silver_Arrow_ShotPoint>().isImmed = true;
            Silver_Arrow_ShotPoint.GetComponent<Silver_Arrow_ShotPoint>().ISCMax = 4;
        }

        if(Selected_Second && !ChangeTwice)
        {
            ChangeTwice = true;
            Silver_Arrow_ShotPoint.GetComponent<Silver_Arrow_ShotPoint>().ISCMax = 3;
        }

        if(Selected_Last)
        {
            this.Selected = true;
            //치확 증가 예정
            this.FreeStamina = true;
        }

        if(Silver_Arrow_ShotPoint.GetComponent<Silver_Arrow_ShotPoint>().ISCAble)
        {
            Silver_Arrow_Weapon.GetComponent<Silver_Arrow_Weapon>().sp.color = Redcolor;
            Silver_Arrow_ShotPoint.GetComponent<Silver_Arrow_ShotPoint>().Immediate_Shot_Count = 0;
            if (Input.GetMouseButtonDown(1) && !Input.GetMouseButtonDown(0))
            {
                if(FreeStamina) 
                {
                    //CameraShake.instance.cameraShake();       카메라가 흔들리면서 마우스 좌표에 영향이 끼친다. 화살이 이상한 방향으로 튀어버림
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
