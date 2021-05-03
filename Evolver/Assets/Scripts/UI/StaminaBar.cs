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
        slider.maxValue = Player_Stat.instance.DefaultStaminaMax;    //그냥 HealthMax로 해버리면 HP창이 항상 가득 차있어서 방사능 스프라이트와 겹쳐버린다.
        slider.value = Player_Stat.instance.stamina;                 //슬라이더의 현재 값을 플레이어의 체력으로 설정
    }
}
