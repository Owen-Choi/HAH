using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack_is_the_Best_Defence : Physical_Manager
{
   
    private void Update()
    {
        if (this.Selected)
        {
            this.Selected = false;
            Player_Stat.instance.damage += 5f;
            Player_Stat.instance.armor -= 5f;
            // ��ġ �����ؾ��� ���� �ִ�.
        }
    }
}