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
        slider.maxValue = Player_Stat.instance.DefaultHealthMax;
        slider.value = Player_Stat.instance.DefaultHealthMax;
    }

    void Update()
    {
        if (slider.value >= Player_Stat.instance.health)
            slider.value -= decreaseRate * Time.deltaTime;

        if(slider.value <= Player_Stat.instance.health)
        {
            slider.value = Player_Stat.instance.health;
        }
    }
}
