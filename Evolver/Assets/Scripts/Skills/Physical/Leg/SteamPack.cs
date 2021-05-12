using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SteamPack : Physical_Manager
{
    private bool Selected_Once;

    private void Update()
    {
        if(this.Selected && !this.Selected_Once)
        {
            this.Selected = false;
            this.Selected_Once = true;
            // # 최대체력 5퍼센트 감소(수치 조정 가능), 이동속도, 차징속도 증가
            Player_Stat.instance.DefaultHealthMax -= Player_Stat.instance.DefaultHealthMax * 0.1f;
            Player_Stat.instance.moveSpeed += 1f;
            //Player_Stat.instance.ChargingSpeed +=     : 일단 ChargingSpeed 변수가 제대로 동작하는지가 ShotPoint 오류로 인해 불분명하다. 이것부터 수정을 하고 마저 작업해야할 것 같다.
        }
    }
}
