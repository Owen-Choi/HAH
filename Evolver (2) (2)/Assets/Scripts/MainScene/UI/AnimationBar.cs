using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnimationBar : MonoBehaviour
{
    public float decreaseRate;
    public Slider slider;

    void Start()
    {
        slider = GetComponent<Slider>();
        slider.maxValue = Player_Stat.instance.DefaultHealthMax;        //Start 함수에서만 넣어서 Update가 안된다. 수정해야할 듯.
        slider.value = Player_Stat.instance.DefaultHealthMax;
    }

    void Update()
    {
        // 조건문 걸어서 필요할 때만 수정하고싶은데....
        slider.maxValue = Player_Stat.instance.DefaultHealthMax;

        if (slider.value >= Player_Stat.instance.health)
            slider.value -= decreaseRate * Time.deltaTime;

        if (slider.value <= Player_Stat.instance.health)
        {
            slider.value = Player_Stat.instance.health;
        }
    }
}
