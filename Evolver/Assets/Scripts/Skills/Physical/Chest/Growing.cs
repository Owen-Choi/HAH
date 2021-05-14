using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Growing : Physical_Manager
{
    int PlayerLevel;
    private void Awake()
    {
        PlayerLevel = Player_Stat.instance.Physical_Level;
    }

    void Update()
    {
        if (this.Selected)
        {
            this.Selected = false;
            if(PlayerLevel < Player_Stat.instance.Physical_Level)       //���� ������ ���� �����ϴ� �Ͱ� �ٸ��ٸ� �������� ���� �ڵ��̴�.
            {
                PlayerLevel = Player_Stat.instance.Physical_Level;
                Player_Stat.instance.DefaultHealthMax += 5f;           
            }
        }
    }
}
