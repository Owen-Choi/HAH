using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaminaRecoveryIncrease :  Physical_Manager
{
    void Update()
    {
        if (this.Selected)
        {
            this.Selected = false;
            Player_Stat.instance.Stamina_recovery_speed += 1f;          //��ġ ���� ���ɼ� ����.
        }
    }
}
