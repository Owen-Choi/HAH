using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadioActiveLimit : Physical_Manager
{
    public GameObject Player;
    float RadioActive;  bool Canceled;
    void Update()
    {
        if (this.Selected)
        {
            if(Player_Stat.instance.RadioActive >= 90f)
            {
                Canceled = true;
                Player.GetComponent<Player>().CancelInvoke("StackRadioActive");     //���� ��ġ�� 90 �̻��̶�� ���� ������ �����
            }
            else if(Canceled)
            {
                Canceled = false;
                Player.GetComponent<Player>().StackRadioActive();                   
            }
        }
    }
}
