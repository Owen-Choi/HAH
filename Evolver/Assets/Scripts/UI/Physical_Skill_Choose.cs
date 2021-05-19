using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Physical_Skill_Choose : Physical_Manager
{
    public GameObject Leg;
    public GameObject Arm;
    public GameObject Chest;
    public GameObject Head;
    public GameObject Physic_System;
    public int Min; public int Max;
    Physical_Manager One;
    Physical_Manager Two;
    void Update()
    {
        if (Leg.gameObject.activeSelf)
        {
            Min = 0;
            Max = 5;
            StartCoroutine("WaitForUpdate");
            One = Physic_System.GetComponent<Physical_Manager>().Physic_Skill_Choose(1);
            Two = Physic_System.GetComponent<Physical_Manager>().Physic_Skill_Choose(2);
            // ��������Ʈ resources ������ �־�ΰ� �ҷ����� �۾� �ϱ�
        }

        if (Arm.gameObject.activeSelf)
        {
            Min = 10;
            Max = 16;
            StartCoroutine("WaitForUpdate");
        }

        if (Chest.gameObject.activeSelf)
        {
            Min = 20;
            Max = 28;   //���� ����
            StartCoroutine("WaitForUpdate");
        }

        if (Head.gameObject.activeSelf)
        {
            //Min =
            //Max = 
        }
    }
    IEnumerator WaitForUpdate()
    {
        yield return new WaitForEndOfFrame();
    }
}
