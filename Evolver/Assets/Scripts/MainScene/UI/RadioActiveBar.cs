using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class RadioActiveBar : MonoBehaviour
{
    public Slider slider;
    void Start()
    {
        slider = GetComponent<Slider>();
    }

    
    void Update()
    {
        slider.maxValue = Player_Stat.instance.DefaultHealthMax;
        slider.value = Player_Stat.instance.RadioActive;
    }
}
