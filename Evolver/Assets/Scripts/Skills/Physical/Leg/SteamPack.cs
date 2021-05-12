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
            // # �ִ�ü�� 5�ۼ�Ʈ ����(��ġ ���� ����), �̵��ӵ�, ��¡�ӵ� ����
            Player_Stat.instance.DefaultHealthMax -= Player_Stat.instance.DefaultHealthMax * 0.1f;
            Player_Stat.instance.moveSpeed += 1f;
            //Player_Stat.instance.ChargingSpeed +=     : �ϴ� ChargingSpeed ������ ����� �����ϴ����� ShotPoint ������ ���� �Һи��ϴ�. �̰ͺ��� ������ �ϰ� ���� �۾��ؾ��� �� ����.
        }
    }
}
