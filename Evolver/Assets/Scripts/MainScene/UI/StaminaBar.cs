using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class StaminaBar : MonoBehaviour
{
    public Slider slider;
    void Start()
    {
        slider = GetComponent<Slider>();
    }

    void Update()
    {
        slider.maxValue = Player_Stat.instance.DefaultStaminaMax;    //�׳� HealthMax�� �ع����� HPâ�� �׻� ���� ���־ ���� ��������Ʈ�� ���Ĺ�����.
        slider.value = Player_Stat.instance.stamina;                 //�����̴��� ���� ���� �÷��̾��� ü������ ����
    }
}
